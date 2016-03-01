using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars
{
    /// <summary>
    /// Builder for Operations calendar.
    /// </summary>
    public class OperationsCalendarBuilder
                        : IEntityBuilder<OperationalCalendar> {

        public OperationalCalendar entity {
            get { return _operational_calendar; }
        }

        /// <summary>
        ///     An operational calendar_name.
        /// </summary>
        /// <param name="value">
        ///     The value of an operational calendar name.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public OperationsCalendarBuilder calendar_name
                                            ( string value ) {

            _operational_calendar.calendar_name = value;
            return this;
        }

        /// <summary>
        ///     Shift calendar to be added.
        /// </summary>
        /// <param name="the_value">
        ///     A shift calendar
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public OperationsCalendarBuilder add_shift_calendar
                                            ( ShiftCalendar the_value ) {

            _operational_calendar.ShiftCalendars.Add(the_value);
            return this;
        }

        public ShiftCalendarBuilder add_shift_calendar () {

            var result = new ShiftCalendarBuilder();
            
            add_shift_calendar( result.entity );
            return result;
        } 

        public OperationsCalendarBuilder add_time_allocation
                                            ( TimeAllocation the_value ) {

            _operational_calendar.TimeAllocations.Add(the_value);
            return this;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="OperationsCalendarBuilder"/> class.
        /// </summary>
        /// <param name="the_operational_calendar">The the_operation_calendar.</param>
        public OperationsCalendarBuilder( OperationalCalendar the_operational_calendar ) {

            Guard.IsNotNull(the_operational_calendar, "the_operation_calendar");

            _operational_calendar = new OperationalCalendar
                                            {
                                                id = the_operational_calendar.id,
                                                calendar_name = the_operational_calendar.calendar_name
                                            };
        }

        private readonly OperationalCalendar _operational_calendar;
    }
}