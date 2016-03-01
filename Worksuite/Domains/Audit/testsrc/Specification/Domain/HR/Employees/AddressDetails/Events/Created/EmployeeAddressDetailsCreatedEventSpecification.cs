using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Created
{
    public class EmployeeAddressDetailsCreatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeAddressDetailsCreatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeAddressDetailsCreatedEventFixture();
        }
    }
}