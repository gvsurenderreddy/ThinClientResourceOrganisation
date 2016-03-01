﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class An_email_does_not_have_at_sign_at_the_start_or_the_end : HRSpecification
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
        public void cannot_have_at_sign_at_the_start()
        {
            var at_sign = "@";
            var update_request = new UpdateRequest
                {
                    employee_id = employee.id,
                    email = at_sign + employee.email,
                };

            command.execute(update_request);

            var email_updated = query.execute(
                    new EmployeeIdentity{employee_id = update_request.employee_id}
                );

            Assert.IsFalse(email_updated.result.email.StartsWith(at_sign));
        }

        [TestMethod]
        public void cannot_have_at_sign_at_the_end()
        {
            var at_sign = "@";
            var update_request = new UpdateRequest
            {
                employee_id = employee.id,
                email = employee.email + at_sign,
            };

            command.execute(update_request);

            var email_updated = query.execute(
                    new EmployeeIdentity { employee_id = update_request.employee_id }
                );

            Assert.IsFalse(email_updated.result.email.EndsWith(at_sign));
        }

    }
}
