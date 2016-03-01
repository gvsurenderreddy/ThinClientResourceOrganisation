using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.get;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.post;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.RemoveAllocation.post
{
    public class RemoveResourceAllocationController : Controller
    {
        public ActionResult SubmitRequest(ResourceAllocationIdentity the_remove_allocation_identity)
        {
            var remove_request = _get_remove_resource_allocation_request.execute(the_remove_allocation_identity);
            var response = _remove_resource_allocation.execute(remove_request.result);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveResourceAllocationController( IRemoveResourceAllocationFromPatternRequestHandler the_remove_resource_allocation
                                                 , IGetRemoveResourceAllocationFromPatternRequestHandler the_get_remove_resource_allocation_request)
        {
            _remove_resource_allocation = Guard.IsNotNull(the_remove_resource_allocation, "the_remove_resource_allocation");
            _get_remove_resource_allocation_request = Guard.IsNotNull(the_get_remove_resource_allocation_request, "the_get_remove_resource_allocation_request");
        }

        private readonly IRemoveResourceAllocationFromPatternRequestHandler _remove_resource_allocation;
        private readonly IGetRemoveResourceAllocationFromPatternRequestHandler _get_remove_resource_allocation_request;
    }
}