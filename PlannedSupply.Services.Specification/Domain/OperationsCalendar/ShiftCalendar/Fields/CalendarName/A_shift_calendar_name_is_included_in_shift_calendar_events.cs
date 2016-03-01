using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Fields.CalendarName
{
    public class A_shift_calendar_name_is_included_in_shift_calendar_events
    {
        [TestClass]
        public class shift_calendar_created_event
                        : PlannedSupplyResponseCommandSpecification<NewShiftCalendarRequest
                                                                    , NewShiftCalendarResponse
                                                                    , NewShiftCalendarFixture>
        {
            [TestMethod]
            public void calendar_name_is_included_in_the_shift_calendar_created_event()
            {
                fixture.execute_command();

                fixture
                    .get_shift_calendar_created_event_for(fixture.entity)
                    .Match(

                        has_value:
                            created_event => created_event.calendar_name.Should().Be(fixture.entity.calendar_name),

                        nothing:
                            () => Assert.Fail("A ShiftCalendarCreatedEvent was not published")
                    );
            }
        }

        [TestClass]
        public class shift_calendar_updated_event
                         : PlannedSupplyResponseCommandSpecification<UpdateShiftCalendarRequest
                                                                    , UpdateShiftCalendarResponse
                                                                    , UpdateShiftCalendarFixture>
        {
            [TestMethod]
            public void calendar_name_is_included_in_the_shift_calendar_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_shift_calendar_update_event_for(fixture.request)
                    .Match(

                        has_value:
                            updated_event => updated_event.calendar_name.Should().Be(fixture.entity.calendar_name),

                        nothing:
                            () => Assert.Fail("A ShiftCalendarCreatedEvent was not published")
                    );
            }
        }
    }
}