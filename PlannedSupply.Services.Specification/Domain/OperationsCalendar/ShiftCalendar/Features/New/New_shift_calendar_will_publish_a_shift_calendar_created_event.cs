using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New {

    [TestClass]
    public class New_shift_calendar_will_publish_a_shift_calendar_created_event 
                        : PlannedSupplyResponseCommandSpecification< NewShiftCalendarRequest
                                                                   , NewShiftCalendarResponse
                                                                   , NewShiftCalendarFixture> {


        [TestMethod]
        public void will_publish_a_shift_calendar_created_event () {

            fixture.execute_command();

            fixture
                .get_shift_calendar_created_event_for( fixture.entity )
                .Match(
                    has_value:
                        e => {
                            e.operations_calendar_id.Should().Be( fixture.request.operations_calendar_id );
                            e.shift_calendar_id.Should().Be( fixture.entity.id );
                        },

                    nothing: 
                        () => Assert.Fail("A ShiftCalendarCreatedEvent was not published."  )
                );
        }
    }
}