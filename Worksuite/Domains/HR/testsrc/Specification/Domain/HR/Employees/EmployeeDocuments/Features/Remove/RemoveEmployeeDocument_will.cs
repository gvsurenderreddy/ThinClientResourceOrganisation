using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeDocuments;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.Remove
{
    [TestClass]
    public class RemoveEmployeeDocument_will : HRSpecification
    {
        [TestMethod]
        public void delete_the_entry()
        {
            var employee_document = builder.name("A name").entity;
            var employee = emp_helper
                           .add()
                           .employee_document(employee_document)
                           .entity
                            ;

            var response = command.execute(new EmployeeDocumentIdentity { employee_id = employee.id, employee_document_id = employee_document.id });

            // Assert
            Assert.IsFalse(response.has_errors);
            employee.EmployeeDocuments.Should().NotContain(employee_document);
        }

        protected override void test_setup()
        {
            builder = new EmployeeDocumentBuilder(new EmployeeDocument());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();
            command = DependencyResolver.resolve<IRemoveEmployeeDocument>();
        }

        private IRemoveEmployeeDocument command;
        private EmployeeHelper emp_helper;
        private EmployeeDocumentBuilder builder;
    }

    [TestClass]
    public class Remove_employee_document_details
                        : HRSpecification
    {
        [TestMethod]
        public void should_raise_an_employee_document_removed_event()
        {
            fixture.execute_command();

            fixture
                .get_last_document_removed_event_for(fixture.remove_request)
                .Match(

                    has_value:
                        removed_event => { },

                    nothing:
                        () => Assert.Fail("An EmployeeDocumentRemoveEvent was not published")

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<RemoveDocumentFixture>();
        }

        private RemoveDocumentFixture fixture;
    }
}