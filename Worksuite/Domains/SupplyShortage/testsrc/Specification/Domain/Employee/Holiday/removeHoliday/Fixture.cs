using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.removeHoliday
{
    public class RemoveHolidayHandlerFixture
    {
        public RemoveHolidayResponse execute_command()
        {
            employee_helper
                .add()
                .set_employee_id(request.employee_id)
                ;

            return request_handler.execute(request);
        }

        public Maybe<HolidayRemovedEvent> check_for_holiday_removed_event(RemoveHolidayRequest holiday_request)
        {

            var created_event = events_publisher
                .published_events
                .SingleOrDefault(e => e.employee_id == holiday_request.employee_id);

            return created_event != null
                   ? new Just<HolidayRemovedEvent>(created_event) as Maybe<HolidayRemovedEvent>
                   : new Nothing<HolidayRemovedEvent>();
            ;
        }
        public RemoveHolidayHandlerFixture(EmployeeSupplyShortageHelper the_employee_helper
            , RemoveHolidayRequestBuilder the_request_builder
            , IRemoveHolidayRequestHandler the_request_handler
            , FakeEventPublisher<HolidayRemovedEvent> the_events_publisher)
        {
            employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
            request_handler = Guard.IsNotNull(the_request_handler, "the_request_handler");
            request_builder = Guard.IsNotNull(the_request_builder, "the_request_builder");
            events_publisher = Guard.IsNotNull(the_events_publisher, "the_events_publisher");
        }

         public RemoveHolidayRequest request { get; set; }

         public RemoveHolidayRequestBuilder request_builder { get; private set; }
         public EmployeeSupplyShortageHelper employee_helper { get; private set; }

         private readonly IRemoveHolidayRequestHandler request_handler;
         private readonly FakeEventPublisher<HolidayRemovedEvent> events_publisher;
    }
}
