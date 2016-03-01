using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup
{
    public class HolidayListViewBuilder
                                    : IEntityBuilder<HolidayListView>
    {
        public HolidayListView entity { get { return holiday_list; } }

        public HolidayListViewBuilder( )
        {
            holiday_list = new HolidayListView();
        }

        public HolidayListViewBuilder employee_id( int employee_id )
        {
            holiday_list.employee_id = employee_id;
            return this;
        }

        public HolidayListViewBuilder holiday_date( DateTime holiday_date )
        {
            holiday_list.holiday_date = holiday_date;
            return this;
        }

        private readonly HolidayListView holiday_list;

    }
}
