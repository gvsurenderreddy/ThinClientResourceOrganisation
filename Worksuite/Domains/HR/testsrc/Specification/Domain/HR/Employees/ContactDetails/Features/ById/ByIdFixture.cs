using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.ById;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.ById 
{

    public class ByIdFixture : HRSpecification
    {
        protected IGetContactDetailsById query;
        protected IEntityRepository<Employee> repository;
        protected TitleHelper title_helper;

        protected override void test_setup()
        {
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
            query = DependencyResolver.resolve<IGetContactDetailsById>();

            title_helper = DependencyResolver.resolve<TitleHelper>();
        }


        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected Response<EmployeeContactDetails> execute_query(Employee employee)
        {

            return query.execute(new EmployeeIdentity { employee_id = employee.id });

        }

    }

}