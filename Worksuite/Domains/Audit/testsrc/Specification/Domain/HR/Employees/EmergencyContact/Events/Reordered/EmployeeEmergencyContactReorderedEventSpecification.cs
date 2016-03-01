using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Reordered
{
    public class EmployeeEmergencyContactReorderedEventSpecification
                         : AuditSpecification
    {
        public EmployeeEmergencyContactReorderedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();
             fixture=new EmployeeEmergencyContactReorderedEventFixture();
        }
    }
}