using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetById;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.GetById
{
    [TestClass]
    public class Returns : HRSpecification
    {
        [TestMethod]
        public void the_emergency_contact()
        {
            var emergency_contact = builder.name("A contact");
            var employee = emp_helper
                           .add().emergency_contact(emergency_contact.entity)
                           .entity;

            var response = query.execute(new EmergencyContactIdentity { employee_id = employee.id, emergency_contact_id = emergency_contact.entity.id });

            emergency_contact.entity.id.Should().Be(response.result.emergency_contact_id);
        }

        protected override void test_setup()
        {
            base.test_setup();
            query = DependencyResolver.resolve<IGetEmergencyContactById>();
            builder = new EmergencyContactBuilder(new EmergencyContact());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

        }

        private IGetEmergencyContactById query;
        private EmergencyContactBuilder builder;
        private EmployeeHelper emp_helper;
    }
}