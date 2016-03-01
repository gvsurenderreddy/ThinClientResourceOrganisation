using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.addSickness.post
{
    public class AddEmployeeSicknessRequestHandlerFixture
    {

        public AddSicknessResponse execute_command()
        {
            employee_helper
                .add()
                .set_employee_id(request.employee_id)
                ;

            return request_handler.execute(request);
        }


        public Maybe<SicknessCreatedEvent> get_sickness_created_event(AddSicknessRequest sickness_request)
        {

            var created_event = events_publisher
                .published_events
                .SingleOrDefault(e => e.employee_id == sickness_request.employee_id);

             return created_event != null
                    ? new Just<SicknessCreatedEvent>(created_event) as Maybe<SicknessCreatedEvent>
                    : new Nothing<SicknessCreatedEvent>();
                ;
        }

        public AddEmployeeSicknessRequestHandlerFixture(EmployeeSupplyShortageHelper the_employee_helper
            , AddSicknessRequestBuilder the_request_builder
            , IAddSicknessRequestHandler the_request_handler
            , FakeEventPublisher<SicknessCreatedEvent> the_events_publisher)
        {
            employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
            request_handler = Guard.IsNotNull(the_request_handler, "the_request_handler");
            request_builder = Guard.IsNotNull(the_request_builder, "the_request_builder");
            events_publisher = Guard.IsNotNull(the_events_publisher, "the_events_publisher");
        }

        public AddSicknessRequest request { get; set; }

        public AddSicknessRequestBuilder request_builder { get; private set; }
        public EmployeeSupplyShortageHelper employee_helper { get; private set; }

        private readonly IAddSicknessRequestHandler request_handler;
        private readonly FakeEventPublisher<SicknessCreatedEvent> events_publisher;
    }
}