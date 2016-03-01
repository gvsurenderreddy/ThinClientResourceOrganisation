using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit
{
    public class UpdateEmploymentDetailsFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture< UpdateEmploymentDetailsRequest,
                                                                           UpdateEmploymentDetailsResponse,
                                                                           IUpdateEmploymentDetails,
                                                                           Employee
                                                                         > {

        public EmployeeBuilder create_employee () {

            var builder = DependencyResolver.resolve<EmployeeBuilder>();

            employee_repository
                .add( builder.entity  )
                ;

            return builder;
        }

        public override Employee entity {

            get {
                return employee_repository
                            .Entities
                            .Single( e => e.id == request.employee_id && e.employeeReference == request.employeeReference )
                            ;
            }
        }


        public Maybe<EmployeeEmploymentDetailsUpdatedEvent> get_last_employee_employment_details_updated_event_for
                                                                ( Employee employee ) {

            var update_event = event_publisher
                                .published_events
                                .LastOrDefault( e => e.employee_id == employee.id )
                                ;

            return update_event != null
                    ? new Just<EmployeeEmploymentDetailsUpdatedEvent>( update_event ) as Maybe<EmployeeEmploymentDetailsUpdatedEvent>
                    : new Nothing<EmployeeEmploymentDetailsUpdatedEvent>()
                    ;
        }

        public UpdateEmploymentDetailsFixture
                       ( IUpdateEmploymentDetails the_update_employment_details_service
                       , IRequestHelper<UpdateEmploymentDetailsRequest> the_update_employment_details_request_builder                       
                       , FakeEmployeeRepository the_employee_repository 
                       , FakeEventPublisher<EmployeeEmploymentDetailsUpdatedEvent> the_event_publisher )
                : base 
                       ( the_update_employment_details_service
                       , the_update_employment_details_request_builder ) {

            employee_repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            event_publisher = Guard.IsNotNull( the_event_publisher, "the_event_publisher " );
        }

        private readonly FakeEmployeeRepository employee_repository;
        private readonly FakeEventPublisher<EmployeeEmploymentDetailsUpdatedEvent> event_publisher;
    }
}