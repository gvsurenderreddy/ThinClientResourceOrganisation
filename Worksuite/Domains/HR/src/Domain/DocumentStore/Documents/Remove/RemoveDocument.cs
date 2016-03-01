using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.Remove
{
    public class RemoveDocument : IRemoveDocument
    {
        public RemoveDocument(IUnitOfWork theUnitOfWork
                              , IEntityRepository<Document> theRepository
                              , Validator theValidator
                              , ICanRemoveDocument theExecutePermission)
        {

            unit_of_work = Guard.IsNotNull(theUnitOfWork, "the_unit_of_work");
            repository = Guard.IsNotNull(theRepository, "the_repository");
            validator = Guard.IsNotNull(theValidator, "the_validator");
            execute_permission = Guard.IsNotNull(theExecutePermission, "the_execute_permission");

        }

        public RemoveDocumentResponse execute(DocumentIdentity the_request)
        {


            return this.set_request(the_request)
                .authorize()
                .find_document()
                .remove_document()
                .commit()
                .build_response();

        }

        private RemoveDocument set_request(DocumentIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new DocumentIdentity
            {
                document_id = Null.Id
            });

            return this;
        }

        private RemoveDocument authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        private RemoveDocument find_document()
        {
            Guard.IsNotNull(request, "the_request");

            document = repository
                                .Entities
                                .SingleOrDefault(e => e.id == request.document_id)
                                ;
            return this;
        }


        private RemoveDocument remove_document()
        {
            if (document != null)
            {
                repository.remove(document);
            }

            return this;
        }

        private RemoveDocument commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private RemoveDocumentResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
                return response_builder.build();
            }

            response_builder.add_message(ValidationMessages.remove_was_successfull);
            return response_builder.build();
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Document> repository;
        private readonly Validator validator;
        private readonly ICanRemoveDocument execute_permission;
        private readonly ResponseBuilder<DocumentIdentity, RemoveDocumentResponse> response_builder = new ResponseBuilder<DocumentIdentity, RemoveDocumentResponse>();

        private DocumentIdentity request;
        private Document document;

    }
}