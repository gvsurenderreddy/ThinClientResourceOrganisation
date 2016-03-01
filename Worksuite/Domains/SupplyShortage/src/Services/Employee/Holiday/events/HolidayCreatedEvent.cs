using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.events
{
    public sealed class HolidayCreatedEvent : EmployeeIdentity
    {
        public DateTime holiday_date { get; set; }
    }
}
