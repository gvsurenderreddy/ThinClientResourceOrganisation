using WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeePersonalDetailsUpdated
{
    public abstract class EmployeePersonalDetailsUpdatedEventSpecification : HRQuerySpecification
    {
        public EmployeePersonalDetailsUpdatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeePersonalDetailsUpdatedFixture();
        }

    }
}
