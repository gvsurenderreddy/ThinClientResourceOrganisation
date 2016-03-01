
namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove
{
    public class RemoveShiftBreakRequest : ShiftBreakIdentity
    {
        public string off_set { get; set; }

        public string duration { get; set; }

        public bool is_paid { get; set; }
    }
}
