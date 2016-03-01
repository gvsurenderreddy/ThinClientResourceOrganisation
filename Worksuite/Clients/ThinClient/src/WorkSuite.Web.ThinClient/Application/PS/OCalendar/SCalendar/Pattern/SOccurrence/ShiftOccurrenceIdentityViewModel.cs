using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences
{
    public class ShiftOccurrenceIdentityViewModel
    {
        public ShiftOccurrenceIdentity identity { get; set; }
        public IEnumerable<IsAViewElement> view_elements { get; set; }
    }
}