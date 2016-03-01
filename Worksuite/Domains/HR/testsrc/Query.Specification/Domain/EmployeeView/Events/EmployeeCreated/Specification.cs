using WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeCreated
{
    public abstract class EmployeeCreatedEventSpecification : HRQuerySpecification
    {
        public EmployeeCreatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeCreatedFixture();
        }

    }
}
