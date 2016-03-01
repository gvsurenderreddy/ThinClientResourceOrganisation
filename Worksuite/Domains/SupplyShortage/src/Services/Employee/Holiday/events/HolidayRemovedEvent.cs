using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.events
{
    public class HolidayRemovedEvent : EmployeeIdentity
    {
        public DateTime holiday_date { get; set; }
    }
}
