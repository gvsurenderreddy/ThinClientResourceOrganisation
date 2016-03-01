using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New
{
    public class NewAddressFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<NewAddressRequest, NewAddressResponse, INewAddress, Address>
    {
        public Maybe<EmployeeAddressDetailsCreatedEvent> get_last_address_details_created_event_for(Address the_address)
        {
            var created_event = event_publisher
                                    .published_events
                                    .LastOrDefault(e => e.address_id == the_address.id)
                                    ;

            return created_event != null
                            ? new Just<EmployeeAddressDetailsCreatedEvent>(created_event) as Maybe<EmployeeAddressDetailsCreatedEvent>
                            : new Nothing<EmployeeAddressDetailsCreatedEvent>()
                            ;
        }

        public override Address entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                return repository
                    .Entities
                    .Single(e => e.id == response.result.employee_id)
                    .Address
                    .Single(a => a.id == response.result.address_id)
                    ;
            }
        }

        public NewAddressFixture
                       (INewAddress the_command,
                       IRequestHelper<NewAddressRequest> the_request_builder,
                       IEntityRepository<Employee> the_employee_repository,
                       FakeEventPublisher<EmployeeAddressDetailsCreatedEvent> the_event_publisher
                       )
            : base(the_command
                   , the_request_builder)
        {
            repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeAddressDetailsCreatedEvent> event_publisher;
    }
}