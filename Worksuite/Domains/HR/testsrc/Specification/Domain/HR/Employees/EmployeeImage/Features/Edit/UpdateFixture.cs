using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeImage.Features.Edit
{
    public class UpdateFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateRequest, UpdateResponse, IUpdate, Employee>
    {
        public Maybe<EmployeeImageDetailsUpdatedEvent> get_last_image_details_updated_event_for(Employee the_employee)
        {
            var updated_event = event_publisher
                                    .published_events
                                    .LastOrDefault(e => e.employee_id == the_employee.id)
                                    ;

            return updated_event != null
                        ? new Just<EmployeeImageDetailsUpdatedEvent>(updated_event) as Maybe<EmployeeImageDetailsUpdatedEvent>
                        : new Nothing<EmployeeImageDetailsUpdatedEvent>()
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
                       , IEntityRepository<Employee> the_repository
                       , FakeEventPublisher<EmployeeImageDetailsUpdatedEvent> the_event_publisher
                       )
            : base(the_command
                   , the_request_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");

            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeImageDetailsUpdatedEvent> event_publisher;
    }
}