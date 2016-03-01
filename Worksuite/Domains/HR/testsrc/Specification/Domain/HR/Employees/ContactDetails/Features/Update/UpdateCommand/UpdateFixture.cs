using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.UpdateCommand
{
    public class UpdateFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateRequest, UpdateResponse, IUpdate, Employee>
    {
        public Maybe<EmployeeContactDetailsUpdatedEvent> get_last_contact_details_updated_event_for(Employee employee)
        {
            var updated_event = event_publisher
                                    .published_events
                                    .LastOrDefault(e => e.employee_id == employee.id)
                                    ;

            return updated_event != null
                            ? new Just<EmployeeContactDetailsUpdatedEvent>(updated_event) as Maybe<EmployeeContactDetailsUpdatedEvent>
                            : new Nothing<EmployeeContactDetailsUpdatedEvent>()
                            ;
        }

        public override Employee entity
        {
            get
            {
                return repository
                        .Entities
                        .Single(e => e.id == request.employee_id)
                        ;
            }
        }

        public UpdateFixture
                       (IUpdate the_command
                       , IRequestHelper<UpdateRequest> the_request_builder
                       , IEntityRepository<Employee> the_repository,
                       FakeEventPublisher<EmployeeContactDetailsUpdatedEvent> the_event_publisher)
            : base(the_command
                   , the_request_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeContactDetailsUpdatedEvent> event_publisher;
    }
}