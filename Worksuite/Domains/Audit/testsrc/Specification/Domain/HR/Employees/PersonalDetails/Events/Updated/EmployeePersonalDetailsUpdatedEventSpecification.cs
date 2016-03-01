using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated
{
    public class EmployeePersonalDetailsUpdatedEventSpecification
                    : AuditSpecification
    {
        public EmployeePersonalDetailsUpdatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeePersonalDetailsUpdatedEventFixture();
        }
    }
}