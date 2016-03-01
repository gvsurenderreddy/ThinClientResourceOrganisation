using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.New {

    public class NewEmployeeDocumentFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture
                        < NewEmployeeDocumentRequest
                        , NewEmployeeDocumentResponse
                        , INewEmployeeDocument
                        , EmployeeDocument > {

        public Maybe<EmployeeDocumentUploadedEvent> get_employee_document_uploaded_event_for
                                                        ( NewEmployeeDocumentRequest new_employee_document_request ) {
            var update_event = events_publisher
                                    .published_events
                                    .Single(e => e.employee_id == new_employee_document_request.employee_id)
                                    ;

            return update_event != null
                    ? new Just<EmployeeDocumentUploadedEvent>(update_event) as Maybe<EmployeeDocumentUploadedEvent>
                    : new Nothing<EmployeeDocumentUploadedEvent>()
                    ;
        }

        public override EmployeeDocument entity {

            get {
                Guard.IsNotNull( response, "response" );

                return repository
                    .Entities
                    .Single(e => e.id == response.result.employee_id)
                    .EmployeeDocuments
                    .Single(a => a.id == response.result.employee_document_id)
                    ;
            }
        }

        public NewEmployeeDocumentFixture
                       ( INewEmployeeDocument the_command
                       , IRequestHelper<NewEmployeeDocumentRequest> the_request_builder
                       , IEntityRepository<Employee> the_employee_repository )
                : base ( the_command
                       , the_request_builder ) {

            repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeDocumentUploadedEvent>>();
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeDocumentUploadedEvent> events_publisher;
    }
}