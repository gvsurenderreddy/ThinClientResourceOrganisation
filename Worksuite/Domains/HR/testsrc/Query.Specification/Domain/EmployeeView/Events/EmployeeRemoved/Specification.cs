using WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeRemoved
{
    public abstract class EmployeeRemovedEventSpecification : HRQuerySpecification
    {
        public EmployeeRemovedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeRemovedFixture();
        }

    }
}
