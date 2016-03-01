using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.listReportQuery
{
    public class GetAllocationRequestDetailsEditorItemsFixture
    {
        public void execute_query()
        {

           response = query.execute();
        }

        public FindConfirmResourceAllocationEditorViewBuilder add()
        {
            return confirm_resource_allocation_editor_view_helper.add();
        }
        public GetAllocationRequestDetailsEditorItemsFixture(FindConfirmResourceAllocationEditorViewHelper confirm_resource_allocation_editor_view_helper
                                                          , GetAllocationRequestDetailsEditorItemsReport query
                                                           )
        {
            this.confirm_resource_allocation_editor_view_helper = Guard.IsNotNull(confirm_resource_allocation_editor_view_helper, "confirm_resource_allocation_list_view_helper");
            this.query = Guard.IsNotNull(query,"query");

        }
        public FindConfirmResourceAllocationEditorViewHelper confirm_resource_allocation_editor_view_helper;
        public GetAllocationRequestDetailsEditorItemsReport query;
        public IEnumerable<AllocationRequestDetailsEditorItem> response;
    }
}
