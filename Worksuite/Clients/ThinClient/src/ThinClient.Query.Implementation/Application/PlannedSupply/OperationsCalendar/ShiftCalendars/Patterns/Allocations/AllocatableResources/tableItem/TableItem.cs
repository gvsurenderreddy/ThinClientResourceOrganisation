using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem
{
    public class GetAllocatableResourcesTableItems
    {
        public IEnumerable<GetAllocatableResourcesDetailsTableItem> execute()
        {
            var resualt = query_repository.Entities.Select(x => new GetAllocatableResourcesDetailsTableItem
            {
                employee_id = x.employee_id,
                forename = x.forename,
                surname = x.surname,
                employee_reference = x.employee_reference,
                location = x.location,
                job_title = x.job_title,
            });

            
            return resualt;

        }

        public GetAllocatableResourcesTableItems(IEntityRepository<AllocatableResourcesTableView> query_repository)
        {
            this.query_repository = Guard.IsNotNull(query_repository, "query_repository");
        }
        private readonly IEntityRepository<AllocatableResourcesTableView> query_repository;
    }
}
