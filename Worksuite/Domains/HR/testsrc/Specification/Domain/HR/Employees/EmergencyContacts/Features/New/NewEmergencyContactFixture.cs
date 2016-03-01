using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.New {

    public class NewEmergencyContactFixture 
                                         : ResponseCommandVerifiedByAnEntitiesStateFixture<NewEmergencyContactRequest
                                         , NewEmergencyContactResponse
                                         , INewEmergencyContact
                                         , EmergencyContact> {

        public Maybe<EmployeeEmergencyContactDetailsCreateEvent> get_last_emergency_contact_details_created_event_for(EmergencyContact the_emergency_contact)
        {
            var created_event = event_publisher
                                    .published_events
                                    .LastOrDefault(e => e.emergency_contact_id == the_emergency_contact.id)
                                    ;

            return created_event != null
                            ? new Just<EmployeeEmergencyContactDetailsCreateEvent>(created_event) as Maybe<EmployeeEmergencyContactDetailsCreateEvent>
                            : new Nothing<EmployeeEmergencyContactDetailsCreateEvent>()
                            ;
        }

        public override EmergencyContact entity {
             get {
                Guard.IsNotNull( response, "response" );

                           return repository
                               .Entities
                               .Single(e => e.id == response.result.employee_id)
                               .EmergencyContacts
                               .Single( a => a.id == response.result.emergency_contact_id )
                               ;            
                }
        }

        public NewEmergencyContactFixture
                                        ( INewEmergencyContact the_command
                                        , IRequestHelper<NewEmergencyContactRequest> the_request_builder
                                        , IEntityRepository<Employee>  the_employee_repository
                                        , FakeEventPublisher<EmployeeEmergencyContactDetailsCreateEvent> the_event_publisher) 
               
            : base ( the_command
                , the_request_builder ) {

            repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
                }


        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeEmergencyContactDetailsCreateEvent> event_publisher;
     }
}