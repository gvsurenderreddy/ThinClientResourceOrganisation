using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.New
{
    public class NewEmployeeQualification_will
    {
        [TestClass]
        public class Given_an_employee_when_a_qualification_is_added_then_it_should_be_in_the_employee_EmployeeQualifications_collection
                            : CommandCommitedChangesSpecification<  NewEmployeeQualificationRequest,
                                                                    NewEmployeeQualificationResponse,
                                                                    NewEmployeeQualificationFixture
                                                                 > { }
    }

    [TestClass]
    public class Get_new_employee_qualification_request
                        : HRSpecification
    {
        [TestMethod]
        public void should_return_a_valid_new_employee_qualification_request()
        {
            Assert.IsTrue( _employee_qualification_request.employee_id == _employee.id );
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_new_employee_qualification_request     = DependencyResolver.resolve< IGetNewEmployeeQualificationRequest >();

            _employee_helper                            = DependencyResolver.resolve< EmployeeHelper >();
            _employee                                   = _employee_helper
                                                                .add()
                                                                .entity;

            _employee_qualification_request             = _get_new_employee_qualification_request
                                                                .execute( new EmployeeIdentity
                                                                {
                                                                    employee_id = _employee.id
                                                                })
                                                                ;
        }

        private IGetNewEmployeeQualificationRequest _get_new_employee_qualification_request;
        private EmployeeHelper _employee_helper;
        private Employee _employee;
        private NewEmployeeQualificationRequest _employee_qualification_request;
    }

    [TestClass]
    public class Adding_a_qualification_to_an_employee
                    : HRSpecification
    {
        [TestMethod]
        public void should_raise_employee_skill_created_event()
        {
            fixture.execute_command(null);

            fixture
                .get_employee_qualification_created_event_for(fixture.create_new_request)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created
                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<NewEmployeeQualificationFixture>();
        }

        private NewEmployeeQualificationFixture fixture;
    }
}