using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.addSickness.post
{
    public class AddSicknessRequestBuilder
    {
         public AddSicknessRequestBuilder set_employee_id( int employee_id )
        {
            request.employee_id = employee_id;

            return this;
        }

        public AddSicknessRequestBuilder set_day( string day )
        {
            request.sickness_date.day = day;

            return this;
        }

        public AddSicknessRequestBuilder set_month( string month )
        {
            request.sickness_date.month = month;

            return this;
        }

        public AddSicknessRequestBuilder set_year( string year )
        {
            request.sickness_date.year = year;

            return this;
        }
        
        public AddSicknessRequest build_request( )
        {
            return request;
        }

        public AddSicknessRequestBuilder(AddSicknessRequest request)
        {
            this.request = Guard.IsNotNull( request, "request" );
            request.sickness_date = new DateRequest( );
        }

        private readonly AddSicknessRequest request;
    }
}
