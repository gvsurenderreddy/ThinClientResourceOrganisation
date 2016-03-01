using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Fields.Email.Update
{
    [TestClass]
    public class An_email_does_not_match_the_simple_pattern : HRSpecification
    {
        private IUpdate command;
        private EmployeeHelper emp_helper;
        private Employee employee;

        protected override void test_setup()
        {
            base.test_setup();

            command = DependencyResolver.resolve<IUpdate>();
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

            setup_employee_email();

        }


        private void setup_employee_email()
        {
            employee = emp_helper
                           .add()
                           .forename("Fred")
                           .surname("Smith")
                           .entity;
        }

        [TestMethod]
        public void does_not_have_character_between_at_sign_and_dot()
        {
            var update_request = new UpdateRequest
                {
                    employee_id = employee.id,
                    email = @"abc@.com",
                };

            var update_response = command.execute(update_request);

            Assert.IsTrue(update_response.has_errors);
        }


        [TestMethod]
        public void does_not_have_character_between_dot_and_at_sign()
        {
            var update_request = new UpdateRequest
            {
                employee_id = employee.id,
                email = @"abc.@com",
            };

            var update_response = command.execute(update_request);

            Assert.IsTrue(update_response.has_errors);
        }

        [TestMethod]
        public void allow_anything_matching_simple_pattern()
        {
            var any_chars_before_at_sign = @"a(email comment allowed)";
            var at_sign = "@";
            var any_chars_after_at_sign = @"*&^£|<+~crazy domai#-b!t.%${[}]_/\>";
            var dot = ".";
            var any_chars_after_dot = @"£|<+~crazy domai#-b!t.%${[}]_>";


            var update_request = new UpdateRequest
            {
                employee_id = employee.id,
                email = any_chars_before_at_sign + at_sign + any_chars_after_at_sign + dot + any_chars_after_dot,
            };

            var update_response = command.execute(update_request);

            Assert.IsFalse(update_response.has_errors);
        }

    }
}
