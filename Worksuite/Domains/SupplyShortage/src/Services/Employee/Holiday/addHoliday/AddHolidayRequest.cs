using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday
{
    public class AddHolidayRequest : EmployeeIdentity
    {
        public DateRequest holiday_date { get; set; }
    }
}
