using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Fields.Qualification
{
    [TestClass]
    public class employee_qualification_can_be_set
                            : HRSpecification
    {
        [TestMethod]
        public void should_assign_a_qualification_to_an_employee_first_time_successfully()
        {
            WorkSuite.HR.HR.ReferenceData.Qualification qualification = _qualification_helper
                                                .add()
                                                .description( "A qualification" )
                                                .entity;

            var response = _create_new_employee_qualification_command
                                    .execute( new NewEmployeeQualificationRequest
                                                {
                                                    employee_id = _employee.id,
                                                    qualification_id = qualification.id
                                                });

            EmployeeQualification employee_qualification = _employee
                                                                .EmployeeQualifications
                                                                .Single( eq => eq.id == response.result.employee_qualification_id )
                                                                ;

            Assert.IsTrue( qualification.id == employee_qualification.qualification.id );
        }

        [TestMethod]
        public void should_not_be_able_to_assign_the_same_qualification_again_to_an_employee()
        {
            WorkSuite.HR.HR.ReferenceData.Qualification qualification = _qualification_helper
                                                                            .add()
                                                                            .description( "A qualification" )
                                                                            .entity;
            _employee_qualification = _employee_qualification_builder
                                            .qualification( qualification )
                                            .entity
                                            ;
            _employee = _employee_helper
                                .add()
                                .employee_qualification( _employee_qualification )
                                .entity
                                ;

            var response = _create_new_employee_qualification_command
                                    .execute( new NewEmployeeQualificationRequest
                                    {
                                        employee_id = _employee.id,
                                        qualification_id = qualification.id
                                    });

            Assert.IsTrue( response.has_errors );
        }

        [TestMethod]
        public void should_not_be_able_to_assign_a_qualification_to_an_employee_that_is_set_to_hidden()
        {
            WorkSuite.HR.HR.ReferenceData.Qualification qualification = _qualification_helper
                                                                            .add()
                                                                            .description( "A qualification" )
                                                                            .is_hidden( true )
                                                                            .entity;

            var response = _create_new_employee_qualification_command
                                    .execute( new NewEmployeeQualificationRequest
                                    {
                                        employee_id = _employee.id,
                                        qualification_id = qualification.id
                                    });

            Assert.IsTrue( response.has_errors );            
        }

        protected override void test_setup()
        {
            base.test_setup();

            _create_new_employee_qualification_command  = DependencyResolver.resolve< INewEmployeeQualification >();
            _qualification_helper                       = DependencyResolver.resolve< QualificationHelper >();
            _employee_qualification_builder             = new EmployeeQualificationBuilder( new EmployeeQualification() );

            _employee_repository                        = DependencyResolver.resolve< IEntityRepository< Employee > >();
            _employee_helper                            = DependencyResolver.resolve< EmployeeHelper >();

            setup_employee_qualification();
        }

        private void setup_employee_qualification()
        {
            _employee_qualification = _employee_qualification_builder
                                            .entity;
            _employee = _employee_helper
                            .add()
                            .employee_qualification(_employee_qualification)
                            .entity;
        }

        private INewEmployeeQualification _create_new_employee_qualification_command;
        private EmployeeQualificationBuilder _employee_qualification_builder;
        private QualificationHelper _qualification_helper;

        private IEntityRepository< Employee > _employee_repository;
        private EmployeeHelper _employee_helper;

        private Employee _employee;
        private EmployeeQualification _employee_qualification;
    }
}
