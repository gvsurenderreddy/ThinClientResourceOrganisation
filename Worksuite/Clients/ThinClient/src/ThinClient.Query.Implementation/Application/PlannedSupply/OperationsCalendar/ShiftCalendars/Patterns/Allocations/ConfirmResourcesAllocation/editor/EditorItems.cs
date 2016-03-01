using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor
{
    public class GetAllocationRequestDetailsEditorItemsReport
    {
        public IEnumerable<AllocationRequestDetailsEditorItem> execute()
        {
            var result = repository.Entities.Select(x => new AllocationRequestDetailsEditorItem
            {
                employee_id = x.employee_id,
                name = x.name  ,
                employee_reference = x.employee_reference,
                job_title = x.job_title,
                location = x.location
            });

            return result;
        }

        public GetAllocationRequestDetailsEditorItemsReport(IEntityRepository<ConfirmResourceAllocationEditorView> repository)
        {
            this.repository = Guard.IsNotNull(repository, "repository");
        }
        private readonly IEntityRepository<ConfirmResourceAllocationEditorView> repository;
    }
}
