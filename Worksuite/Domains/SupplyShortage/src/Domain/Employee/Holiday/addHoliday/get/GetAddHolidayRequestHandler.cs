using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employees;
using WorkSuite.Library.Persistence;
using System.Linq;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.get
{
    public class GetAddHolidayRequestHandler : IGetAddHolidayRequestHandler
    {
        public GetAddHolidayResponse execute( GetAddHolidayRequest request )
        {
            return this
                    .set_request( request )
                    .find_employee( )
                    .build_response( )
                    ;
        }

        private GetAddHolidayRequestHandler set_request( GetAddHolidayRequest request )
        {
            this.request = request;

            return this;
        }

        private GetAddHolidayRequestHandler find_employee( )
        {
            Guard.IsNotNull( request, "request" );

            employee_supply_shortage = employee_supply_shortage_repository.Entities.Single( e => e.employee_id == request.employee_id );

            return this;
        }

        private GetAddHolidayResponse build_response( )
        {
            Guard.IsNotNull( employee_supply_shortage, "employee_supply_shortage" );

            response_builder.set_response(new AddHolidayRequest
            {
                employee_id = employee_supply_shortage.employee_id
            });

            return response_builder.build( );
        }

        public GetAddHolidayRequestHandler( IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository
                                          , ServiceStatusResponseBuilder<AddHolidayRequest, GetAddHolidayResponse> response_builder )
        {
            this.employee_supply_shortage_repository = Guard.IsNotNull( employee_supply_shortage_repository, "employee_supply_shortage_repository" );
            this.response_builder = Guard.IsNotNull( response_builder, "response_builder" );
        }

        private EmployeeSupplyShortage employee_supply_shortage;
        private GetAddHolidayRequest request;

        private readonly IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private readonly ServiceStatusResponseBuilder<AddHolidayRequest, GetAddHolidayResponse> response_builder;
    }
}
