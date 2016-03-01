using System;
using System.Linq.Expressions;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Mapper
{
    /// <summary>
    ///     Mapper to map operations calendar to Operations Calendar Summary
    /// </summary>
    public class OperationalCalendarSummaryMapper
                        : IOperationalCalendarSummaryMapper
    {
        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Expression<Func<OperationsCalendars.OperationalCalendar, OperationsCalendarDetails>> Map
        {
            get
            {
                return operations_calendar => new OperationsCalendarDetails
                {
                    operations_calendar_id = operations_calendar.id,
                    calendar_name = operations_calendar.calendar_name
                };
            }
        }
    }
}