using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries
{
    public class GetDetailsOfJobTitlesEligibleForEmployee
                    : GetDetailsOfReferencDataEligibleForEmployee<JobTitle, JobTitleDetails>,
                        IGetDetailsOfJobTitlesEligibleForEmployee
    {
        public GetDetailsOfJobTitlesEligibleForEmployee(IQueryRepository<Employee> the_employee_repository,
                                                        IQueryRepository<JobTitle> the_entity_repository
                                                       )
            : base(the_employee_repository, the_entity_repository)
        {
        }

        protected override IEnumerable<JobTitle> get_entry_assigned_to_employee(IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.job_title);
        }
    }
}