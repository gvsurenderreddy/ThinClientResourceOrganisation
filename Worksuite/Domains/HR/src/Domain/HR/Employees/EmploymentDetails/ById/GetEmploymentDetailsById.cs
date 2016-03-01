using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.ById
{
    public class GetEmploymentDetailsById : IGetEmploymentDetailsById
    {
        public GetEmploymentDetailsById(IQueryRepository<Employee> theEmployeeRepository,
                                        IQueryRepository<JobTitle> theJobTitleRepository,
                                        IQueryRepository<Location> theLocationRepository
                                       )
        {
            _employeeRepository = Guard.IsNotNull(theEmployeeRepository, "theEmployeeRepository");
            _jobTitleRepository = Guard.IsNotNull(theJobTitleRepository, "theJobTitleRepository");
            _locationRepository = Guard.IsNotNull(theLocationRepository, "theLocationRepository");
        }

        public Response<EmployeeEmploymentDetails> execute(EmployeeIdentity employeeIdentity)
        {
            var employee = _employeeRepository
                                .Entities
                                .Single(e => e.id == employeeIdentity.employee_id)
                                ;

            var job_description = string.Empty;
            if (employee.job_title != null)
            {
                var jobTitle = _jobTitleRepository
                                    .Entities
                                    .Single(jt => jt.id == employee.job_title.id)
                                    ;
                job_description = jobTitle.description;
            }

            var location_description = string.Empty;
            if (employee.location != null)
            {
                var location = _locationRepository
                                    .Entities
                                    .Single(l => l.id == employee.location.id)
                                    ;
                location_description = location.description;
            }

            return new Response<EmployeeEmploymentDetails>
                {
                    result = new EmployeeEmploymentDetails
                        {
                            employee_id = employee.id,
                            employeeReference = employee.employeeReference,
                            job_description = job_description,
                            location_description = location_description
                        }
                };
        }

        private readonly IQueryRepository<Employee> _employeeRepository;
        private readonly IQueryRepository<JobTitle> _jobTitleRepository;
        private readonly IQueryRepository<Location> _locationRepository;
    }
}