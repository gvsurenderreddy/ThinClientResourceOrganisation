using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Remove
{
    public class RemoveEmployeeDocument : IRemoveEmployeeDocument
    {
        public RemoveEmployeeDocumentResponse execute(EmployeeDocumentIdentity the_request)
        {
            return this
                .set_request(the_request)
                .find_employee()
                .find_employee_document()
                .create_employee_document_removed_event()
                .remove_employee_document()
                .commit()
                .publish_document_removed_event()
                .build_response()
                ;
        }

        private RemoveEmployeeDocument set_request(EmployeeDocumentIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_remove_employee_document_request");

            response_builder.set_response(
                                        new EmployeeDocumentIdentity
                                        {
                                            employee_id = Null.Id,
                                            employee_document_id = Null.Id
                                        }
                                         );

            return this;
        }

        private RemoveEmployeeDocument find_employee()
        {
            if (response_builder.has_errors) return this;

            employee = employee_repository
                            .Entities
                            .Single(e => e.id == request.employee_id);
            return this;
        }

        private RemoveEmployeeDocument find_employee_document()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmployeeDocuments, "employee.EmployeeDocument");

            employee_document = employee
                                    .EmployeeDocuments
                                    .Single(a => a.id == request.employee_document_id);
            return this;
        }

        private RemoveEmployeeDocument create_employee_document_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee_document, "employee_document");

            employee_document_removed_event = new EmployeeDocumentRemovedEvent
            {
                employee_id = employee.id,
                employee_document_id = employee_document.document_id,
                name = employee_document.name,
                description = employee_document.description
            };

            return this;
        }

        private RemoveEmployeeDocument remove_employee_document()
        {
            if (response_builder.has_errors) return this;
            if (employee_document == null) return this;

            Guard.IsNotNull(employee_document, "employee_document");

            employee.EmployeeDocuments.Remove(employee_document);
            employee_repository.remove(employee_document);

            return this;
        }

        private RemoveEmployeeDocument commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private RemoveEmployeeDocument publish_document_removed_event()
        {
            if (response_builder.has_errors) return this;

            event_publisher_document_removed.publish(employee_document_removed_event);

            return this;
        }

        private RemoveEmployeeDocumentResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.remove_was_successfull);
            }

            return response_builder.build();
        }

        public RemoveEmployeeDocument(IUnitOfWork the_unit_of_work,
                                        IEntityRepository<Employee> the_employee_repository,
                                        IEventPublisher<EmployeeDocumentRemovedEvent> the_event_publisher_document_removed
                                     )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher_document_removed = Guard.IsNotNull(the_event_publisher_document_removed,
                                                               "the_event_publisher_document_removed"
                                                              );
        }

        private readonly IEntityRepository<Employee> employee_repository;
        private readonly IUnitOfWork unit_of_work;

        private readonly ResponseBuilder<EmployeeDocumentIdentity, RemoveEmployeeDocumentResponse> response_builder =
                                                                        new ResponseBuilder<EmployeeDocumentIdentity, RemoveEmployeeDocumentResponse>();

        private readonly IEventPublisher<EmployeeDocumentRemovedEvent> event_publisher_document_removed;

        private EmployeeDocumentIdentity request;
        private Employee employee;
        private EmployeeDocument employee_document;
        private EmployeeDocumentRemovedEvent employee_document_removed_event;
    }
}