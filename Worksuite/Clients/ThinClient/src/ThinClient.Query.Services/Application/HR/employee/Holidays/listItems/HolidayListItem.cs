using System;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems
{
    public class HolidayListItem
    {
        public int employee_id { get; set; }
        public string holiday_date_display { get; set; }
        public DateTime holiday_date { get; set; }
    }
}
