using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeDocuments;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.Remove
{
    public class RemoveDocumentFixture
    {
        public EmployeeDocumentIdentity remove_request
        {
            get
            {
                return _document_identity_helper.get_identity();
            }
        }

        public Maybe<RemoveEmployeeDocumentResponse> response
        {
            get;
            private set;
        }

        public void execute_command()
        {
            response = _command.execute(remove_request).to_maybe();
        }

        public Maybe<EmployeeDocumentRemovedEvent> get_last_document_removed_event_for(EmployeeDocumentIdentity the_document)
        {
            var removed_event = _event_publisher
                                    .published_events
                                    .FirstOrDefault(a => a.employee_document_id == the_document.employee_document_id)
                                    ;

            return removed_event != null
                        ? new Just<EmployeeDocumentRemovedEvent>(removed_event) as Maybe<EmployeeDocumentRemovedEvent>
                        : new Nothing<EmployeeDocumentRemovedEvent>()
                        ;
        }

        public RemoveDocumentFixture()
        {
            this.response = new Nothing<RemoveEmployeeDocumentResponse>();
            _document_identity_helper = DependencyResolver.resolve<DocumentIdentityHelper>();

            _command = DependencyResolver.resolve<IRemoveEmployeeDocument>();
            _event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeDocumentRemovedEvent>>();
        }

        private readonly DocumentIdentityHelper _document_identity_helper;
        private readonly IRemoveEmployeeDocument _command;
        private readonly FakeEventPublisher<EmployeeDocumentRemovedEvent> _event_publisher;
    }
}