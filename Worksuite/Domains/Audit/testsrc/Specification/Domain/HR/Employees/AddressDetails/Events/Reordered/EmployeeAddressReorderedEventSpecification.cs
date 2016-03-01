using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Reordered
{
    public class EmployeeAddressReorderedEventSpecification
                        : AuditSpecification
    {
        public EmployeeAddressReorderedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeAddressReorderedEventFixture();
        }
    }
}