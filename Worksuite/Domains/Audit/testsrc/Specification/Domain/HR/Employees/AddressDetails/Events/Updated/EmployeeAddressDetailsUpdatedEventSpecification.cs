using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Updated
{
    public class EmployeeAddressDetailsUpdatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeAddressDetailsUpdatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeAddressDetailsUpdatedEventFixture();
        }
    }
}