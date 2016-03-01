using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update
{
    public class UpdateAddressFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateAddressRequest, UpdateAddressResponse, IUpdateAddress, Address>
    {
        public Maybe<EmployeeAddressDetailsUpdatedEvent> get_last_address_details_updated_event_for(Address the_address)
        {
            var created_event = event_publisher
                                    .published_events
                                    .LastOrDefault(a => a.address_id == the_address.id)
                                    ;

            return created_event != null
                        ? new Just<EmployeeAddressDetailsUpdatedEvent>(created_event) as Maybe<EmployeeAddressDetailsUpdatedEvent>
                        : new Nothing<EmployeeAddressDetailsUpdatedEvent>()
                        ;
        }

        public override Address entity
        {
            get
            {
                return repository
                        .Entities
                        .Single(e => e.id == request.employee_id)
                        .Address
                        .Single(c => c.id == request.address_id)
                        ;
            }
        }

        public UpdateAddressFixture
                       (IUpdateAddress the_command
                       , IRequestHelper<UpdateAddressRequest> the_request_builder
                       , IEntityRepository<Employee> the_employee_repository
                       , FakeEventPublisher<EmployeeAddressDetailsUpdatedEvent> the_event_publisher
                        )
            : base(the_command
                   , the_request_builder)
        {
            repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeAddressDetailsUpdatedEvent> event_publisher;
    }
}