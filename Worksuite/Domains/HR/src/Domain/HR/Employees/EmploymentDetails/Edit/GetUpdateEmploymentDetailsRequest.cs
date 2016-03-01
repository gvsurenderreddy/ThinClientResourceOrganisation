using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit
{
    public class GetUpdateEmploymentDetailsRequest : IGetUpdateEmploymentDetailsRequest
    {
        public GetUpdateEmploymentDetailsRequest(IEntityRepository<Employee> theEmployeeRepository,
                                                 IQueryRepository<JobTitle> theJobTitleRepository,
                                                 IQueryRepository<Location> theLocationRepository
                                                )
        {
            _employeeRepository = Guard.IsNotNull(theEmployeeRepository, "theEmployeeRepository");
            _jobTitleRepository = Guard.IsNotNull(theJobTitleRepository, "theJobTitleRepository");
            _locationRepository = Guard.IsNotNull(theLocationRepository, "theLocationRepository");
        }

        public Response<UpdateEmploymentDetailsRequest> execute(EmployeeIdentity employeeIdentity)
        {
            var employee = _employeeRepository
                                .Entities
                                .Single(e => e.id == employeeIdentity.employee_id)
                                ;

            var job_title_id = -1;

            if (employee.job_title != null)
            {
                var jobTitle = _jobTitleRepository
                                    .Entities
                                    .Single(jt => jt.id == employee.job_title.id)
                                    ;
                job_title_id = jobTitle.id;
            }

            var location_id = -1;

            if (employee.location != null)
            {
                var location = _locationRepository
                                    .Entities
                                    .Single(l => l.id == employee.location.id)
                                    ;
                location_id = location.id;
            }

            return new Response<UpdateEmploymentDetailsRequest>
                {
                    result = new UpdateEmploymentDetailsRequest
                        {
                            employee_id = employee.id,
                            employeeReference = employee.employeeReference,
                            job_title_id = job_title_id,
                            location_id = location_id
                        }
                };
        }

        private IEntityRepository<Employee> _employeeRepository;
        private readonly IQueryRepository<JobTitle> _jobTitleRepository;
        private readonly IQueryRepository<Location> _locationRepository;
    }
}