using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDetails.GetAll
{
    public class GetAllFixture : HRSpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAllEmployeeDetails>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();

            title_helper = DependencyResolver.resolve<TitleHelper>();
            gender_helper = DependencyResolver.resolve<GenderHelper>();
            address_builder = DependencyResolver.resolve<AddressBuilder>();
            job_title_helper = DependencyResolver.resolve<JobTitleHelper>();
            location_helper = DependencyResolver.resolve<LocationHelper>();
        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected IGetAllEmployeeDetails query;
        protected IEntityRepository<Employee> repository;
        protected TitleHelper title_helper;
        protected GenderHelper gender_helper;
        protected AddressBuilder address_builder;
        protected JobTitleHelper job_title_helper;
        protected LocationHelper location_helper;
    }
}