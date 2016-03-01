using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems
{
    public class GetHolidayListItemsFixture
    {
        public void execute_query( )
        {
            Guard.IsNotNull( request, "request" );

            response = get_holiday_list_items.execute( request );
        }

        public void set_request( EmployeeIdentity request )
        {
            this.request = request;
        }

        public HolidayListViewBuilder add( )
        {
            return holiday_list_view_helper.add();
        }

        public GetHolidayListItemsFixture( HolidayListViewHelper holiday_list_view_helper
                                                 , IGetHolidayListItems get_holiday_list_items )
        {
            this.holiday_list_view_helper = Guard.IsNotNull( holiday_list_view_helper, "holiday_list_view_helper" );
            this.get_holiday_list_items = Guard.IsNotNull( get_holiday_list_items, "get_holiday_list_items" );
        }

        private readonly HolidayListViewHelper holiday_list_view_helper;
        private readonly IGetHolidayListItems get_holiday_list_items;
        
        private EmployeeIdentity request;
        public GetHolidayListItemsResponse response { private set; get; }

    }
}
