using Content.Services.HR.Messages;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.HR.Employees.Remove {

    public class RemoveEmployee 
                    : IRemoveEmployee {

        public RemoveResponse execute
                                ( EmployeeIdentity request ) {

            employee_repository
                .GetSingle( e => e.id == request.employee_id )
                .Match( 

                    has_value: 
                        employee => {

                            employee_repository.remove( employee );
                            unit_of_work.Commit();
                            event_publisher.publish( new EmployeeRemovedEvent {
                                employee_id = request.employee_id                                
                            });
                        },
                        
                    nothing:
                        () => {
                            
                            // do nothing at the moment we may want to audit the fact that the request was at some point.
                        }
                );

            return response_builder
                    .add_message( ValidationMessages.confirmation_04_0003 )
                    .build()
                    ;
        }



        public RemoveEmployee
                ( IUnitOfWork the_unit_of_work
                , IEntityRepository<Employee> the_employee_repository 
                , IEventPublisher<EmployeeRemovedEvent> the_event_publisher ) {

            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_title_repository");
            event_publisher = Guard.IsNotNull( the_event_publisher, "the_event_publisher" );
        }


        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> employee_repository;
        private readonly ResponseBuilder<RemoveResponse> response_builder = new ResponseBuilder<RemoveResponse>();

        private readonly IEventPublisher<EmployeeRemovedEvent> event_publisher;
    }
}
