using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit {

    public class GetUpdateEmployeePersonalDetailsRequest 
                    : IGetUpdateEmployeePersonalDetailsRequest {

        public Response<UpdateEmployeePersonalDetailsRequest> execute ( EmployeeIdentity request ) {

            var employee = repository
                            .Entities
                            .Single( e => e.id == request.employee_id )
                            ;

            return new Response<UpdateEmployeePersonalDetailsRequest> {
              
                result = new UpdateEmployeePersonalDetailsRequest {
                    employee_id = employee.id,
                    forename = employee.forename,
                    surname = employee.surname,
                    title_id = employee.title != null ? employee.title.id : NotSpecified.Id,
                    gender_id = employee.gender != null ? employee.gender.id : NotSpecified.Id,
                    marital_status_id = employee.maritalStatus != null ? employee.maritalStatus.id : NotSpecified.Id,
                    nationality_id = employee.nationality != null ? employee.nationality.id : NotSpecified.Id,
                    ethnic_origin_id = employee.ethnicOrigin != null ? employee.ethnicOrigin.id : NotSpecified.Id,
                    othername = employee.othername,
                    birth_place = employee.birth_place,
                    date_of_birth = employee.dateofbirth.ToDateRequest(),
                }
            };
        }

        public GetUpdateEmployeePersonalDetailsRequest ( IEntityRepository<Employee> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

        private IEntityRepository<Employee> repository;
    }
}