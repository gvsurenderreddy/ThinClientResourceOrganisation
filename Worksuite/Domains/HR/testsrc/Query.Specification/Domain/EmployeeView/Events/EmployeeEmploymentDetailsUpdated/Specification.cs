using WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeEmploymentDetailsUpdated
{
    public abstract class EmployeeEmploymentDetailsUpdatedEventSpecification : HRQuerySpecification
    {
        public EmployeeEmploymentDetailsUpdatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeEmploymentDetailsUpdatedFixture();
        }

    }
}
