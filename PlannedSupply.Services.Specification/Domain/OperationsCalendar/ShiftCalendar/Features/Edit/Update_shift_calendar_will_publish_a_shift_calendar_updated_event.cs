using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit
{
    [TestClass]
    public class Update_shift_calendar_will_publish_a_shift_calendar_updated_event
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void will_publish_a_shift_calendar_updated_event()
        {
            fixture.execute_command();

            fixture
                .get_shift_calendar_update_event_for(fixture.request)
                .Match(

                    has_value:
                        update_event => { },

                    nothing:
                        () => Assert.Fail("An ShiftCalendarUpdateEvent was not published")
                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<UpdateShiftCalendarFixture>();
        }

        private UpdateShiftCalendarFixture fixture;
    }
}