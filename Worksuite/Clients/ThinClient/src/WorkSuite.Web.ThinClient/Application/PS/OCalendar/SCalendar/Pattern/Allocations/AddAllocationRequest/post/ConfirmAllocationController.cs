using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.post;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.post
{
    public class ConfirmAllocationController : Controller
    {
        // GET: CreateResourceAllocation
        public ActionResult SubmitRequest(AllocateEmployeeToPatternRequest the_allocate_resource_request)
        {
            AllocateEmployeeToPatternResponse allocate_resource_response = _allocateEmployeeToPattern.execute(the_allocate_resource_request);

            Response.StatusCode = allocate_resource_response.has_errors ? 400 : 200;

            return Json(allocate_resource_response, JsonRequestBehavior.AllowGet);
        }

        public ConfirmAllocationController(IAllocateEmployeeToPatternRequestHandler theAllocateEmployeeToPattern)
        {
            _allocateEmployeeToPattern = Guard.IsNotNull(theAllocateEmployeeToPattern, "the_allocate_resource");
        }

        private readonly IAllocateEmployeeToPatternRequestHandler _allocateEmployeeToPattern;
    }
}