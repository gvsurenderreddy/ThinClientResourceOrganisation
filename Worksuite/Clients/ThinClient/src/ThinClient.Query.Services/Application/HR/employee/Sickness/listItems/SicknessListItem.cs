using System;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems
{
    public class SicknessListItem
    {
        
        public int employee_id { get; set; }
        public string sickness_date_display { get; set; }
        public DateTime sickness_date { get; set; }
    }
}
