using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.ById {

    public class GetPersonalDetailsById : IGetPersonalDetailsById {

        public Response<EmployeePersonalDetails> execute ( EmployeeIdentity employee_identity ) {
            
            var employee = repository
                             .Entities
                             .Single( e => e.id == employee_identity.employee_id )
                             ;
            return new Response<EmployeePersonalDetails> {
                // to do: (WPM) this needs to be cleaned up as it is a mess
                result = new Employees.EmployeePersonalDetails.EmployeePersonalDetails {
                    employee_id = employee_identity.employee_id,                    
                    forename = employee.forename,
                    surname = employee.surname,
                    gender = employee.gender != null ? employee.gender.description : string.Empty,
                    maritalStatus = employee.maritalStatus != null ? employee.maritalStatus.description : string.Empty,
                    title = employee.title != null ? employee.title.description : string.Empty,
                    nationality = employee.nationality != null ? employee.nationality.description : string.Empty,
                    ethnic_origin = employee.ethnicOrigin != null ? employee.ethnicOrigin.description : string.Empty,
                    othername = employee.othername,
                    birth_place = employee.birth_place,
                    date_of_birth = employee.dateofbirth.FormatForReportIncludeAge(),
                }            
            };

        }

        public GetPersonalDetailsById ( IQueryRepository<Employee> the_repository ) {
            
            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

        private readonly IQueryRepository<Employee> repository;

    }

}