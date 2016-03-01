using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit
{
    public class EditShiftBreakRequest : ShiftBreakIdentity
    {
        public DurationRequest off_set { get; set; }

        public DurationRequest duration { get; set; }

        public bool is_paid { get; set; }
    }
}
