using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.GetUpdateRequestCommand {

    public class IsAGetUpdateRequestWorkSuiteSpecification : HRSpecification {


        protected override void test_setup ( ) {
            command = DependencyResolver.resolve<IGetUpdateEmployeePersonalDetailsRequest>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>( );
            employee = add_employee();

        }

        protected EmployeeBuilder add_employee ( ) {
            var builder = new EmployeeBuilder( new Employee( ) );

            repository.add( builder.entity );

            return builder;
        }

        protected Response<UpdateEmployeePersonalDetailsRequest> update_request {
            get {
                return command.execute( new EmployeeIdentity {employee_id = employee.entity.id });
            }
        }


        protected IEntityRepository<Employee> repository;
        protected IGetUpdateEmployeePersonalDetailsRequest command;
        protected EmployeeBuilder employee;
         
    }
}