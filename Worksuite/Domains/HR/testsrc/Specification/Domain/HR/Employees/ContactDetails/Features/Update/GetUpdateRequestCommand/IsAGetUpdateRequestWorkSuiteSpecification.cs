using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.GetUpdateRequestCommand 
{

    public class IsAGetUpdateRequestWorkSuiteSpecification : HRSpecification
    {

        protected IEntityRepository<Employee> repository;
        protected IGetUpdateRequest command;
        protected EmployeeBuilder employee;

        protected override void test_setup()
        {
            command = DependencyResolver.resolve<IGetUpdateRequest>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
            employee = add_employee();

        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected Response<UpdateRequest> update_request
        {
            get
            {
                return command.execute(new EmployeeIdentity { employee_id = employee.entity.id });
            }
        }



    }
}