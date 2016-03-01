using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.removeSickness
{
    public class RemoveSicknessRequestBuilder
    {
          public RemoveSicknessRequestBuilder set_employee_id( int employee_id )
        {
            request.employee_id = employee_id;

            return this;
        }

        public RemoveSicknessRequestBuilder set_date( DateTime date )
        {
            request.sickness_date = date;

            return this;
        }
        
        public RemoveSicknessRequest build_request( )
        {
            return request;
        }

        public RemoveSicknessRequestBuilder(RemoveSicknessRequest request)
        {
            this.request = Guard.IsNotNull( request, "request" );
            request.sickness_date = new DateTime( );
        }

        private readonly RemoveSicknessRequest request;
    }
}
