using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItemQuery
{
    public class GetAllocatableResourcesTableItemFixture
    {
        public void execute_query()
        {
            response = query.execute();
        }

        public FindAllocatableResourcesTableViewBuilder add()
        {
            return find_allocatable_resources_table_view_helper.add();
        }

        public GetAllocatableResourcesTableItemFixture(FindAllocatableResourcesTableViewHelper find_allocatable_resources_table_view_helper
                                                       , GetAllocatableResourcesTableItems query)
        {
            this.find_allocatable_resources_table_view_helper = Guard.IsNotNull(find_allocatable_resources_table_view_helper,
                "find_employeetable_view_helper");
            this.query = Guard.IsNotNull(query, "query");
        }

        public FindAllocatableResourcesTableViewHelper find_allocatable_resources_table_view_helper;
        public GetAllocatableResourcesTableItems query;
        public IEnumerable<GetAllocatableResourcesDetailsTableItem> response;
    }
}
