using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSummary;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDetails.EmployeeSummary
{
    public class EmployeeSummaryFixture : HRSpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetEmployeeSummary>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
          
        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected IGetEmployeeSummary query;
        protected IEntityRepository<Employee> repository;
    }
}