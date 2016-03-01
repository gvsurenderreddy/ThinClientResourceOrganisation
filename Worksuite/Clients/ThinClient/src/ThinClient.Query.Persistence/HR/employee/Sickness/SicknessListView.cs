using System;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness
{
    public class SicknessListView  : BaseEntity<int>
    {
       
        public virtual int employee_id { get; set; }
        public virtual DateTime sickness_date { get; set; }
    }
}
