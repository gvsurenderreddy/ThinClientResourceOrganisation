using WTS.WorkSuite.HR.Query.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.LocationUpdated
{
    public abstract class LocationUpdatedEventSpecification : HRQuerySpecification
    {
        public LocationUpdatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new LocationUpdatedFixture();
        }

    }
}
