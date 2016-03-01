using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.ById;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.ById {

    public class ByIdFixture : HRSpecification {


        protected override void test_setup ( ) {
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>( );
            query = DependencyResolver.resolve<IGetPersonalDetailsById>( );

            title_helper = DependencyResolver.resolve< TitleHelper > (  );
            maritalStatus_helper = DependencyResolver.resolve< MaritalStatusHelper > (  );
            nationality_helper = DependencyResolver.resolve< NationalityHelper > ();
            ethnic_origin_helper = DependencyResolver.resolve< EthnicOriginHelper > ();
        }


        protected EmployeeBuilder add_employee ( ) {
            var builder = new EmployeeBuilder( new Employee( ) );

            repository.add( builder.entity );

            return builder;
        }

        protected Response<EmployeePersonalDetails> execute_query ( Employee employee) {
            
            return query.execute( new EmployeeIdentity { employee_id = employee.id} );

        }
        protected IGetPersonalDetailsById query;
        protected IEntityRepository<Employee> repository;
        protected TitleHelper title_helper;
        protected MaritalStatusHelper maritalStatus_helper;
        protected NationalityHelper nationality_helper;
        protected EthnicOriginHelper ethnic_origin_helper;

    }

}