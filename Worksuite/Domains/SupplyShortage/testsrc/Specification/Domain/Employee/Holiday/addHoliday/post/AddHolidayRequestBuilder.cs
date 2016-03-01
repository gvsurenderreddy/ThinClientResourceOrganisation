using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.addHoliday.post
{
    public class AddHolidayRequestBuilder
    {
        public AddHolidayRequestBuilder set_employee_id( int employee_id )
        {
            request.employee_id = employee_id;

            return this;
        }

        public AddHolidayRequestBuilder set_day( string day )
        {
            request.holiday_date.day = day;

            return this;
        }

        public AddHolidayRequestBuilder set_month( string month )
        {
            request.holiday_date.month = month;

            return this;
        }

        public AddHolidayRequestBuilder set_year( string year )
        {
            request.holiday_date.year = year;

            return this;
        }
        
        public AddHolidayRequest build_request( )
        {
            return request;
        }

        public AddHolidayRequestBuilder( AddHolidayRequest request )
        {
            this.request = Guard.IsNotNull( request, "request" );
            request.holiday_date = new DateRequest( );
        }

        private readonly AddHolidayRequest request;
    }
}
