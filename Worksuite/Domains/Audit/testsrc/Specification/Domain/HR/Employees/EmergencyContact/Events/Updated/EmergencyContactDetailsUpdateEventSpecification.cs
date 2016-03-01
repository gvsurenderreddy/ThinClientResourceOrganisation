using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Updated
{
    public class EmployeeEmergencyContactDetailsUpdateEventSpecification
                                    : AuditSpecification
    {
        public EmergencyContactDetailsUpdateEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();
            fixture=new EmergencyContactDetailsUpdateEventFixture();
        }
    }
}