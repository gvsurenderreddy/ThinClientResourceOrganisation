using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.removeSickness
{
    public class RemoveSicknessHandlerFixture
    {
        public RemoveSicknessResponse execute_command()
        {
            employee_helper
                .add()
                .set_employee_id(request.employee_id)
                ;

            return request_handler.execute(request);
        }

        public Maybe<SicknessRemovedEvent> check_for_sickness_removed_event(RemoveSicknessRequest sickness_request)
        {

            var created_event = events_publisher
                .published_events
                .SingleOrDefault(e => e.employee_id == sickness_request.employee_id);

            return created_event != null
                   ? new Just<SicknessRemovedEvent>(created_event) as Maybe<SicknessRemovedEvent>
                   : new Nothing<SicknessRemovedEvent>();
            ;
        }

        public RemoveSicknessHandlerFixture(EmployeeSupplyShortageHelper the_employee_helper
            , RemoveSicknessRequestBuilder the_request_builder
            , IRemoveSicknessRequestHandler the_request_handler
            , FakeEventPublisher<SicknessRemovedEvent> the_events_publisher)
        {
            employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
            request_handler = Guard.IsNotNull(the_request_handler, "the_request_handler");
            request_builder = Guard.IsNotNull(the_request_builder, "the_request_builder");
            events_publisher = Guard.IsNotNull(the_events_publisher, "the_events_publisher");
        }

         public RemoveSicknessRequest request { get; set; }

         public RemoveSicknessRequestBuilder request_builder { get; private set; }
         public EmployeeSupplyShortageHelper employee_helper { get; private set; }

         private readonly IRemoveSicknessRequestHandler request_handler;
         private readonly FakeEventPublisher<SicknessRemovedEvent> events_publisher;
    }
}
