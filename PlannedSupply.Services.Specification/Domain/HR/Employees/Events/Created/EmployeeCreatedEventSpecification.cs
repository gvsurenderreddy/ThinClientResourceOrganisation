using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.HR.Employees.Events.Created
{
    public abstract class EmployeeCreatedEventSpecification : PlannedSupplySpecification
    {

        public EmployeeCreatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeCreatedFixture();
        }
    }
}
