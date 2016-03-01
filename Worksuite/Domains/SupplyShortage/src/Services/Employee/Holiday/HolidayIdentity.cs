using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday
{
    public class HolidayIdentity : EmployeeIdentity
    {
        public DateTime? holiday_date { get; set; }
    }
}
