using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.GetAll;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.GetAll
{
    public class GetAllFixture : HRSpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAllNotes>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected IGetAllNotes query;
        protected IEntityRepository<Employee> repository;
      
    }
}