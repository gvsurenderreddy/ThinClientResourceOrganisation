using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars
{
    public class OperationalCalendarIdentityViewModel
    {
        public OperationsCalendarIdentity identity { get; set; }
        public IEnumerable<IsAViewElement> view_elements { get; set; }
    }
}