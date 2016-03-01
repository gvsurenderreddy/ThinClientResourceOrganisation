using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listReport;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.ListItemQuery
{
    public class AllocatedResourcesListItemQueryFixture
    {
        public void execute_query()
        {
            response = query.execute();
        }

        public FindAllocatedResourcesListViewBuilder add()
        {
            return helper.add();
        }

        public AllocatedResourcesListItemQueryFixture( AllocatedResourcesListReport query
                                                     , FindAllocatedResourcesListViewHelper helper)
        {
            this.query = Guard.IsNotNull(query,"query");
            this.helper = Guard.IsNotNull(helper, "helper");
        }

        private readonly AllocatedResourcesListReport query;
        private readonly FindAllocatedResourcesListViewHelper helper;
        public IEnumerable<AllocatedResourcesListItems> response;
    }
}
