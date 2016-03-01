using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listReport
{
    public class AllocatedResourcesListReport
    {
        public IEnumerable<AllocatedResourcesListItems> execute()
        {
            var result = repository.Entities.Select(x => new AllocatedResourcesListItems
            {
                 employee_id = x.employee_id,
                 employee_reference = x.employee_reference,
                 name = x.name,
                 job_title = x.job_title,
                 location = x.location
            });
            return result;
        }

        public AllocatedResourcesListReport(IEntityRepository<AllocatedResourcesListView> repository)
        {
            this.repository = Guard.IsNotNull(repository, "repository");
        }

        private readonly IEntityRepository<AllocatedResourcesListView> repository;
    }
}
