using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.ById;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Fields.Email.Update
{
    [TestClass]
    public class An_email_does_not_have_space_at_the_start_and_end : HRSpecification
    {

        private IGetContactDetailsById query;
        private IUpdate command;
        private EmployeeHelper emp_helper;
        private Employee employee;

        protected override void test_setup()
        {
            base.test_setup();

            command = DependencyResolver.resolve<IUpdate>();
            query = DependencyResolver.resolve<IGetContactDetailsById>();
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

            setup_employee_email();

        }


        private void setup_employee_email()
        {
            employee = emp_helper
                           .add()
                           .forename("Fred")
                           .surname("Smith")
                           .email("a@test.uk")
                           .entity;
        }

        [TestMethod]
        public void cannot_have_space_at_the_start_and_end()
        {
            var space = " ";
            var update_request = new UpdateRequest
                {
                    employee_id = employee.id,
                    email = space + employee.email + space,
                };

            command.execute(update_request);

            var email_updated = query.execute(
                    new EmployeeIdentity{employee_id = update_request.employee_id}
                );

            Assert.AreEqual(update_request.email.Trim(), email_updated.result.email);
        }
        

    }
}
