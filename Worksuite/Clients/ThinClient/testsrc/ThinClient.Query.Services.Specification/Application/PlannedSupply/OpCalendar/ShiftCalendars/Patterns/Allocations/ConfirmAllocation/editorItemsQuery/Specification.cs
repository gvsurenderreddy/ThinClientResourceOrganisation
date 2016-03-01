using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.listReportQuery;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.editorItemsQuery
{
   public class GetAllocationRequestDetailsEditorItemsSpecification : ThinClientQuerySpecification
    {
       protected override void test_setup()
       {
           base.test_setup();
           fixture = DependencyResolver.resolve<GetAllocationRequestDetailsEditorItemsFixture>();
       }

       protected GetAllocationRequestDetailsEditorItemsFixture fixture;
    }
}
