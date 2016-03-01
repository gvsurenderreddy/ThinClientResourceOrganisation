using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems.Setup
{
    public class EmployeeViewScheduleTableViewBuilder : IEntityBuilder<EmployeeViewScheduleTableView>
    {
        public EmployeeViewScheduleTableView entity { get { return employee_view_schedule_table; } }

        public EmployeeViewScheduleTableViewBuilder()
        {
            
            employee_view_schedule_table = new EmployeeViewScheduleTableView();
        }

        public EmployeeViewScheduleTableViewBuilder employee_id(int employee_id)
        {
            employee_view_schedule_table.employee_id = employee_id;
            return this;
        }

        public EmployeeViewScheduleTableViewBuilder display_date(DateTime date)
        {
            employee_view_schedule_table.display_date = date;
            return this;
        }
       
        private readonly EmployeeViewScheduleTableView employee_view_schedule_table;
    }
}
