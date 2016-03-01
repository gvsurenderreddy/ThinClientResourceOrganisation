using Content.Services.HR.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public class NewEmployeeDocument : INewEmployeeDocument
    {
        public NewEmployeeDocument(IEntityRepository<Employee> the_repository
                                    , IUnitOfWork the_unit_of_work
                                    , INewEmployeeDocumentValidator the_validator
                                    , IEventPublisher<EmployeeDocumentUploadedEvent> the_event_publisher_document_uploaded)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            validator = Guard.IsNotNull(the_validator, "the_new_employee_document_validator");
            event_publisher_document_uploaded = Guard.IsNotNull(the_event_publisher_document_uploaded,
                                                                "the_event_publisher_document_uploaded"
                                                               );
        }

        public NewEmployeeDocumentResponse execute(NewEmployeeDocumentRequest the_request)
        {
            return this
                .set_request(the_request)
                .sanitise_request()
                .find_employee()
                .validate_request()
                .create_employee_document()
                .commit()
                .publish_document_uploaded_event()
                .build_response()
                ;
        }

        private NewEmployeeDocument set_request(NewEmployeeDocumentRequest the_request)
        {
            Guard.IsNotNull(the_request, "the_request");

            request = the_request;

            response_builder.set_response(new EmployeeDocumentIdentity
            {
                employee_id = request.employee_id,
                employee_document_id = Null.Id
            });
            return this;
        }

        private NewEmployeeDocument find_employee()
        {
            if (response_builder.has_errors) return this;

            employee = repository
                            .Entities
                            .Single(e => e.id == request.employee_id)
                            ;
            return this;
        }

        private NewEmployeeDocument sanitise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request.name = strip_whitespace(request.name);
            request.content_type = strip_whitespace(request.content_type);
            request.description = strip_whitespace(request.description);
            request.md5_hash = strip_whitespace(request.md5_hash);

            return this;
        }

        private NewEmployeeDocument validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            response_builder.add_errors(validator.validate(request));

            return this;
        }

        private NewEmployeeDocument create_employee_document()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(request, "request");

            new_employee_document = new EmployeeDocument
            {
                name = request.name,
                content_type = request.content_type,
                description = request.description,
                document_id = request.document_id,
                md5_hash = request.md5_hash
            };

            employee.EmployeeDocuments.Add(new_employee_document);

            return this;
        }

        private NewEmployeeDocument commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private NewEmployeeDocument publish_document_uploaded_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(new_employee_document, "new_employee_document");

            event_publisher_document_uploaded.publish(new EmployeeDocumentUploadedEvent
            {
                employee_id = employee.id,
                employee_document_id = new_employee_document.document_id,
                name = new_employee_document.name,
                description = new_employee_document.description
            });

            return this;
        }

        private NewEmployeeDocumentResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                var confirmation = new List<string> { ValidationMessages.confirmation_04_0008 };
                response_builder.add_messages(confirmation);
                response_builder.set_response(new EmployeeDocumentIdentity { employee_id = request.employee_id, employee_document_id = new_employee_document.id });
            }
            else
            {
                response_builder.add_errors(new List<string> {
                    ValidationMessages.warning_03_0001,
                });
            }
            return response_builder.build();
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEventPublisher<EmployeeDocumentUploadedEvent> event_publisher_document_uploaded;
        private EmployeeDocument new_employee_document;
        private Employee employee;
        private NewEmployeeDocumentRequest request;
        private readonly INewEmployeeDocumentValidator validator;
        private readonly ResponseBuilder<EmployeeDocumentIdentity, NewEmployeeDocumentResponse> response_builder = new ResponseBuilder<EmployeeDocumentIdentity, NewEmployeeDocumentResponse>();

        //Utility methods
        private string strip_whitespace(string value)
        {
            return (value == null || value.Trim().Equals("")) ? null : value.Trim();
        }
    }
}