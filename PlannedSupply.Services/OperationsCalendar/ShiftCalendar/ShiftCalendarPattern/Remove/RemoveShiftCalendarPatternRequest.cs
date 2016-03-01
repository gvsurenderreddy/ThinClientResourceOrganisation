namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove
{
    public class RemoveShiftCalendarPatternRequest
                        : ShiftCalendarPatternIdentity
    {
        public string pattern_name { get; set; }

        public int number_of_resources { get; set; }
    }
}