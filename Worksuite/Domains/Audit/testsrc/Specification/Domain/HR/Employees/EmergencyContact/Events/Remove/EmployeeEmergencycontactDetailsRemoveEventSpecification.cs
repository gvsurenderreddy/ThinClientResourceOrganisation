using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Remove
{
    public class EmployeeEmergencyContactDetailsRemoveEventSpecification
                                  : AuditSpecification
    {
        public EmployeeEmergencyContactDetailsRemovedEventFixture fixture { get; private set; }
        protected override void test_setup()
        {
            base.test_setup();
            fixture=new EmployeeEmergencyContactDetailsRemovedEventFixture();
        }
    }
}