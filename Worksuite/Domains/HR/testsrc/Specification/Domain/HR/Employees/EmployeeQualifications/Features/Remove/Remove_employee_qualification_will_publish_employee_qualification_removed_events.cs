using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.Remove
{
    [TestClass]
    public class Remove_an_employee_qualification
                        : HRSpecification
    {
        [TestMethod]
        public void should_raise_an_employee_qualification_removed_event()
        {
            var employee_qualification_identity = new EmployeeQualificationIdentity
                                                        {
                                                            employee_id = employee.id,
                                                            employee_qualification_id = employee_qualification_four.id
                                                        };

            fixture.execute_command(employee_qualification_identity);

            fixture
                .get_last_employee_qualification_removed_event_for(new EmployeeIdentity { employee_id = employee.id })
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

            fixture = DependencyResolver.resolve<RemoveEmployeeQualificationFixture>();
            event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeQualificationRemovedEvent>>();

            qualification_helper = DependencyResolver.resolve<QualificationHelper>();
            employee_helper = DependencyResolver.resolve<EmployeeHelper>();

            qualification_one = qualification_helper.add().description("qualification 1").entity;
            qualification_two = qualification_helper.add().description("qualification 2").entity;
            qualification_three = qualification_helper.add().description("qualification 3").entity;
            qualification_four = qualification_helper.add().description("qualification 4").entity;
            qualification_five = qualification_helper.add().description("qualification 5").entity;
            qualification_six = qualification_helper.add().description("qualification 6").entity;

            employee_qualification_one = create_employee_qualification().qualification(qualification_one).entity;
            employee_qualification_two = create_employee_qualification().qualification(qualification_two).entity;
            employee_qualification_three = create_employee_qualification().qualification(qualification_three).entity;
            employee_qualification_four = create_employee_qualification().qualification(qualification_four).entity;
            employee_qualification_five = create_employee_qualification().qualification(qualification_five).entity;
            employee_qualification_six = create_employee_qualification().qualification(qualification_six).entity;

            employee = employee_helper
                        .add()
                        .employee_qualification(employee_qualification_one)
                        .employee_qualification(employee_qualification_two)
                        .employee_qualification(employee_qualification_three)
                        .employee_qualification(employee_qualification_four)
                        .employee_qualification(employee_qualification_five)
                        .employee_qualification(employee_qualification_six)
                        .entity
                        ;
        }

        protected EmployeeQualificationBuilder create_employee_qualification()
        {
            return new EmployeeQualificationBuilder(new EmployeeQualification());
        }

        private RemoveEmployeeQualificationFixture fixture;
        private FakeEventPublisher<EmployeeQualificationRemovedEvent> event_publisher;

        protected EmployeeHelper employee_helper;
        protected QualificationHelper qualification_helper;

        protected Qualification qualification_one;
        protected Qualification qualification_two;
        protected Qualification qualification_three;
        protected Qualification qualification_four;
        protected Qualification qualification_five;
        protected Qualification qualification_six;

        protected EmployeeQualification employee_qualification_one;
        protected EmployeeQualification employee_qualification_two;
        protected EmployeeQualification employee_qualification_three;
        protected EmployeeQualification employee_qualification_four;
        protected EmployeeQualification employee_qualification_five;
        protected EmployeeQualification employee_qualification_six;

        protected Employee employee;
    }
}