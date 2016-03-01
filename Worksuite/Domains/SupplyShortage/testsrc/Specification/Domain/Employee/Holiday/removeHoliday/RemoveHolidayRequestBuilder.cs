using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.removeHoliday
{
    public class RemoveHolidayRequestBuilder
    {
          public RemoveHolidayRequestBuilder set_employee_id( int employee_id )
        {
            request.employee_id = employee_id;

            return this;
        }

        public RemoveHolidayRequestBuilder set_date( DateTime date )
        {
            request.holiday_date = date;

            return this;
        }
        
        public RemoveHolidayRequest build_request( )
        {
            return request;
        }

        public RemoveHolidayRequestBuilder(RemoveHolidayRequest request)
        {
            this.request = Guard.IsNotNull( request, "request" );
            request.holiday_date = new DateTime( );
        }

        private readonly RemoveHolidayRequest request;
    }
}
