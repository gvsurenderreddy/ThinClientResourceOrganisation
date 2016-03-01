using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Created
{
    public class EmployeeEmergencyContactDetailsCreatedEventSpecification
                                        : AuditSpecification
    {
        public EmergencyContactDetailsCreatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();
            fixture=new EmergencyContactDetailsCreatedEventFixture();
        }
    }
}