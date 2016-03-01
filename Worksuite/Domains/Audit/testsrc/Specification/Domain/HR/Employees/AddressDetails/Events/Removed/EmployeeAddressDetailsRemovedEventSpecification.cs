using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Removed
{
    public class EmployeeAddressDetailsRemovedEventSpecification
                        : AuditSpecification
    {
        public EmployeeAddressDetailsRemovedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeAddressDetailsRemovedEventFixture();
        }
    }
}