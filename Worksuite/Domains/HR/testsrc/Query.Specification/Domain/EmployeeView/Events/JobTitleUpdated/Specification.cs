using WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.JobTitleUpdated
{
    public abstract class JobTitleUpdatedEventSpecification : HRQuerySpecification
    {
        public JobTitleUpdatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new JobTitleUpdatedFixture();
        }

    }
}
