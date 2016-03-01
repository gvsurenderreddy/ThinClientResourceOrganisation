using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.get;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.addHoliday.get
{
    public class GetAddEmployeeHolidayRequestHandlerFixture
    {
        public GetAddHolidayResponse execute_command( )
        {
            int new_employee_id = 1;

            request = new GetAddHolidayRequest { employee_id = new_employee_id };

            employee_supply_shortage_helper
                                .add( )
                                .set_employee_id( new_employee_id )
                                ;
            
            return request_handler.execute( request );
        }

        public GetAddEmployeeHolidayRequestHandlerFixture( FakeUnitOfWork unit_of_work
                                                         , IGetAddHolidayRequestHandler request_handler
                                                         , EmployeeSupplyShortageHelper employee_supply_shortage_helper )
        {
            this.unit_of_work = Guard.IsNotNull( unit_of_work, "unit_of_work" );
            this.request_handler = Guard.IsNotNull( request_handler, "request_handler" );
            this.employee_supply_shortage_helper = Guard.IsNotNull( employee_supply_shortage_helper, "employee_supply_shortage_helper" );
        }

        private readonly IGetAddHolidayRequestHandler request_handler;
        private readonly EmployeeSupplyShortageHelper employee_supply_shortage_helper;

        public GetAddHolidayRequest request;
        public FakeUnitOfWork unit_of_work { get; private set; }
    }
}
