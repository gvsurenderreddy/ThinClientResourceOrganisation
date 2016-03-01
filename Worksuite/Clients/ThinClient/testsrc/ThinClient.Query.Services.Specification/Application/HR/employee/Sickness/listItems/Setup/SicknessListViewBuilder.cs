using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems.Setup
{
    public class SicknessListViewBuilder : IEntityBuilder<SicknessListView>
    {
        public SicknessListView entity { get { return employee_sickness_list; } }

        public SicknessListViewBuilder()
        {
            employee_sickness_list = new SicknessListView();
        }

        public SicknessListViewBuilder employee_id(int employee_id)
        {
            employee_sickness_list.employee_id = employee_id;
            return this;
        }

        public SicknessListViewBuilder sickness_date(DateTime sickness_date)
        {
            employee_sickness_list.sickness_date = sickness_date;
            return this;
        }

      

        private readonly SicknessListView employee_sickness_list;
    }
}
