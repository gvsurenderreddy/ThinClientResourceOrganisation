using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Events.Updated
{
    public class EmployeeContactDetailsUpdatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeContactDetailsUpdatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeContactDetailsUpdatedEventFixture();
        }
    }
}