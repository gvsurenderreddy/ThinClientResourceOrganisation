namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit
{
    public class UpdateShiftCalendarPatternRequest
                        : ShiftCalendarPatternIdentity
    {
        public string pattern_name { get; set; }

        public string number_of_resources { get; set; }

        public string summary_of_allocated_resources { get; set; }
    }
}