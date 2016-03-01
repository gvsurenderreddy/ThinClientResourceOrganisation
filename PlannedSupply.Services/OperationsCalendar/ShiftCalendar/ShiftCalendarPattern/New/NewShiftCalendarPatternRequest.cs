namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New
{
    /// <summary>
    ///     Request accepted by the add new shift calendar pattern command
    /// </summary>

    public class NewShiftCalendarPatternRequest
                        : ShiftCalendarPatternIdentity
    {
        public string pattern_name { get; set; }

        public string number_of_resources { get; set; }
    }
}