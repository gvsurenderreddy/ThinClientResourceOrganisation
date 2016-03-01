using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday
{
    public class RemoveHolidayRequest : EmployeeIdentity
    {
        public DateTime holiday_date { get; set; }
    }
}
