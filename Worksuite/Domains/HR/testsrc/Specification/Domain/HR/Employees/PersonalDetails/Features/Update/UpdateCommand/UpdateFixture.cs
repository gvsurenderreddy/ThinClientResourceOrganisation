using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand {

    public class UpdateEmployeePersonalDetailsFixture 
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateEmployeePersonalDetailsRequest,UpdateEmployeePersonalDetailsResponse,IUpdateEmployeePersonalDetails,Employee> {


        public Maybe<EmployeePersonalDetailsUpdatedEvent> get_last_personal_details_updated_event_for
                                                            ( Employee employee ) {

            var update_event = event_publisher
                                    .published_events
                                    .LastOrDefault( e => e.employee_id == employee.id )
                                    ;

            return update_event != null
                     ? new Just<EmployeePersonalDetailsUpdatedEvent>( update_event ) as Maybe<EmployeePersonalDetailsUpdatedEvent>
                     : new Nothing<EmployeePersonalDetailsUpdatedEvent>()
                     ;
        }

        public override Employee entity {

            get {
                
                return repository
                        .Entities
                        .Single(e => e.id == request.employee_id)
                        ;             
            }
        }

        public UpdateEmployeePersonalDetailsFixture 
                       ( IUpdateEmployeePersonalDetails the_command
                       , IRequestHelper<UpdateEmployeePersonalDetailsRequest> the_request_builder 
                       , IEntityRepository<Employee> the_repository 
                       , FakeEventPublisher<EmployeePersonalDetailsUpdatedEvent> the_event_publisher ) 
                : base ( the_command
                       , the_request_builder ) {
            
            repository = Guard.IsNotNull( the_repository , "the_repository" );
            event_publisher = Guard.IsNotNull( the_event_publisher, "the_event_publisher" );
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeePersonalDetailsUpdatedEvent> event_publisher;
    }
}