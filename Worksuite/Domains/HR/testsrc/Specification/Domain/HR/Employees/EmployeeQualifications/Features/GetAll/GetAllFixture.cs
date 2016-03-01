using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.GetAll;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.GetAll
{
    public class GetAllFixture
                    : HRSpecification
    {
        protected EmployeeBuilder add_employee()
        {
            var employee_builder = new EmployeeBuilder( new Employee() );
            _employee_repository.add( employee_builder.entity );

            return employee_builder;
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_all_employee_qualifications_query = DependencyResolver.resolve< IGetAllEmployeeQualifications >();
            _employee_repository = DependencyResolver.resolve< IEntityRepository< Employee > >();
            _employee_qualification_builder = new EmployeeQualificationBuilder( new EmployeeQualification() );
            _qualification_helper = DependencyResolver.resolve< QualificationHelper >();
        }

        protected IGetAllEmployeeQualifications _get_all_employee_qualifications_query;
        protected IEntityRepository<Employee> _employee_repository;
        protected EmployeeQualificationBuilder _employee_qualification_builder;
        protected QualificationHelper _qualification_helper;
    }
}