using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeImage.Features.Remove
{
    [TestClass]
    public class Remove_will : HRSpecification
    {
        [TestMethod]
        public void delete_the_entry()
        {
            var employee = employee_helper
                           .add()
                           .image_id(7)
                           .entity
                            ;

            var response = command.execute(new EmployeeIdentity { employee_id = employee.id });

            // Assert
            Assert.IsFalse(response.has_errors);
            employee.image_id.Should().Be(Null.Id);
        }

        protected override void test_setup()
        {
            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            command = DependencyResolver.resolve<IRemove>();
        }

        private IRemove command;
        private EmployeeHelper employee_helper;
    }

    [TestClass]
    public class Remove_employee_picture_details
                        : HRSpecification
    {
        [TestMethod]
        public void should_raise_an_employee_image_details_removed_event()
        {
            var employee = employee_helper
                                .add()
                                .image_id(3)
                                .entity
                                ;

            var response = remove_employee_image
                                .execute(new EmployeeIdentity { employee_id = employee.id })
                                ;

            this
                .get_last_image_details_removed_event_for(employee)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created
                );
        }

        private Maybe<EmployeeImageDetailsRemovedEvent> get_last_image_details_removed_event_for(Employee the_employee)
        {
            var removed_event = event_publisher
                                    .published_events
                                    .LastOrDefault(e => e.employee_id == the_employee.id)
                                    ;

            return removed_event != null
                        ? new Just<EmployeeImageDetailsRemovedEvent>(removed_event) as Maybe<EmployeeImageDetailsRemovedEvent>
                        : new Nothing<EmployeeImageDetailsRemovedEvent>()
                        ;
        }

        protected override void test_setup()
        {
            base.test_setup();

            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            remove_employee_image = DependencyResolver.resolve<IRemove>();
            event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeImageDetailsRemovedEvent>>();
        }

        private EmployeeHelper employee_helper;
        private IRemove remove_employee_image;
        private FakeEventPublisher<EmployeeImageDetailsRemovedEvent> event_publisher;
    }
}