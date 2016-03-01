using System;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules
{
    public class EmployeeViewScheduleTableView : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }
        public virtual DateTime? display_date { get; set; }
    }
}
