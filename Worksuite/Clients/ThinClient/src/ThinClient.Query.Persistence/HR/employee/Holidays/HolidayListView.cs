using System;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays
{
    public class HolidayListView : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }
        public virtual DateTime holiday_date { get; set; }
    }
}
