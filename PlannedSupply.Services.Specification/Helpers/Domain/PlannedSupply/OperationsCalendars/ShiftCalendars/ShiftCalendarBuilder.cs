using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars
{
    /// <summary>
    /// Builder for Shift calendar.
    /// </summary>
    public class ShiftCalendarBuilder
                        : IEntityBuilder<ShiftCalendar> {


        public ShiftCalendar entity {
            get { return _shift_calendar; }
        }

        /// <summary>
        ///     Calendar_name the specified value.
        /// </summary>
        /// <param name="the_value">
        ///     calendar_name value
        /// </param>
        /// <returns>
        ///     Builder itself so that we can use the fluent interface to build a shift calendar.
        /// </returns>
        public ShiftCalendarBuilder calendar_name
                                        ( string the_value ) {

            _shift_calendar.calendar_name = the_value;
            return this;
        }

        /// <summary>
        ///     Shift calendar pattern to be added.
        /// </summary>
        /// <param name="the_value">
        ///     A shift calendar pattern
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public ShiftCalendarBuilder add_shift_calendar_pattern
                                        ( ShiftCalendarPattern the_value ) {

            _shift_calendar.ShiftCalendarPatterns.Add( the_value );
            return this;
        }


        public ShiftCalendarBuilder () {
            var id = next_id();

            _shift_calendar = new ShiftCalendar {
                id = id,
                calendar_name = "Calendar " + id                
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ShiftCalendarBuilder"/> class.
        /// </summary>
        /// <param name="the_shift_calendar">
        ///     shift calendar
        /// </param>
        public ShiftCalendarBuilder
                    ( ShiftCalendar the_shift_calendar ) { 

            Guard.IsNotNull( the_shift_calendar, "the_shift_calendar" );

            _shift_calendar = new ShiftCalendar{
                id = the_shift_calendar.id,
                calendar_name = the_shift_calendar.calendar_name
            };
        }

        private int next_id () {
            var identity_provider = new IntIdentityProvider<ShiftCalendar>();

            return identity_provider.next();
        }  

        private readonly ShiftCalendar _shift_calendar;
    }
}