using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.addHoliday.post
{
    public class AddEmployeeHolidayRequestHandlerFixture
    {
        public AddHolidayResponse execute_command( )
        {
            employee_helper
                    .add()
                    .set_employee_id(request.employee_id)
                    ;

            return request_handler.execute( request );
        }

        public HolidayCreatedEvent get_holiday_created_event()
        {
            return
                 events_publisher
                .published_events
                .SingleOrDefault(e => e.employee_id == request.employee_id)
                ;
        }

        public AddEmployeeHolidayRequestHandlerFixture( EmployeeSupplyShortageHelper employee_helper
                                                      , AddHolidayRequestBuilder request_builder
                                                      , IAddHolidayRequestHandler request_handler
                                                      , FakeEventPublisher<HolidayCreatedEvent> events_publisher )
        {
            this.employee_helper = Guard.IsNotNull(employee_helper, "employee_helper");
            this.request_handler = Guard.IsNotNull(request_handler, "request_handler");
            this.request_builder = Guard.IsNotNull(request_builder, "request_builder");
            this.events_publisher = Guard.IsNotNull(events_publisher, "events_publisher");
        }

        public AddHolidayRequest request { get; set; }

        public AddHolidayRequestBuilder request_builder { get; private set; }
        public EmployeeSupplyShortageHelper employee_helper { get; private set; }

        private readonly IAddHolidayRequestHandler request_handler;
        private readonly FakeEventPublisher<HolidayCreatedEvent> events_publisher;


    }
}
