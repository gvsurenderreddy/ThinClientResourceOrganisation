using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Update {

    public class UpdateFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateRequest, UpdateResponse, IUpdate, EmergencyContact> {

        public Maybe<EmployeeEmergencyContactDetailsUpdateEvent> get_last_emergency_contact_updated_event_for(EmergencyContact the_emergency_content)
        {

            var create_event = event_publisher
                                      .published_events
                                      .LastOrDefault(a => a.emergency_contact_id == the_emergency_content.id);

            return create_event != null
                ? new Just<EmployeeEmergencyContactDetailsUpdateEvent>(create_event) as Maybe<EmployeeEmergencyContactDetailsUpdateEvent>
                : new Nothing<EmployeeEmergencyContactDetailsUpdateEvent>();

        }
        
        public override EmergencyContact entity {
            get {

                return repository
                        .Entities
                        .Single( e => e.id == request.employee_id )
                        .EmergencyContacts
                        .Single( c => c.id == request.emergency_contact_id )
                        ;
            }
        }

        public UpdateFixture
                       ( IUpdate the_command
                       , IRequestHelper<UpdateRequest> the_request_builder
                       , IEntityRepository<Employee>  the_employee_repository
                       , FakeEventPublisher<EmployeeEmergencyContactDetailsUpdateEvent> the_event_publisher) 
                
            : base ( the_command
                       , the_request_builder ) {

            repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
                       }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeEmergencyContactDetailsUpdateEvent> event_publisher;
                    }

}