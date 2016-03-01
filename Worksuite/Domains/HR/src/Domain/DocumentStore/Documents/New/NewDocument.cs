using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.IO;
using WTS.WorkSuite.Library.IO.Cryptography;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    public class NewDocument : INewDocument
    {
        public NewDocument(IEntityRepository<Document> the_repository
                          , IUnitOfWork the_unit_of_work
                          , INewDocumentValidator the_document_validator
                          , ICanCreateDocument the_execute_permission)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_unit_of_work");
            validator = Guard.IsNotNull(the_document_validator, "the_document_validator");
        }

        public NewDocumentResponse execute(NewDocumentRequest the_request)
        {
            return this.set_request(the_request)
                .authorize()
                .sanitise_request()
                .validate_request()
                .create_document()
                .commit()
                .build_response();
        }



        private NewDocument set_request(NewDocumentRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new DocumentIdentity
            {
                document_id = Null.Id
            });

            return this;
        }

        private NewDocument authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        private NewDocument sanitise_request()
        {
            if ( response_builder.has_errors ) return this;
            
            Guard.IsNotNull( request, "request" );

            request.name = strip_whitespace(request.name);
            request.content_type = strip_whitespace(request.content_type);
            
            return this;
        }

        private NewDocument validate_request()
        {
            if (response_builder.has_errors) return this;


            Guard.IsNotNull(request, "request");

            response_builder.add_errors(validator.validate(request));

            return this;
        }

        private NewDocument create_document()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            document = new Document
            {
                name = request.name,
                md5_value = new FileHelper().GetMD5Value(request.data),
                content_type = request.content_type,
                data = request.data
            };
            repository.add(document);
            return this;
        }

        private NewDocument commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private NewDocumentResponse build_response()
        {

            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
                return response_builder.build();
            }

            response_builder.set_response(new DocumentIdentity
            {
                 document_id = document.id
            });

            return response_builder.build();
        }

        private string strip_whitespace(string value)
        {

            return (value == null || value.Trim().Equals("")) ? null : value.Trim();
        }



        private readonly INewDocumentValidator validator;

        private readonly ICanCreateDocument execute_permission;
        private readonly IEntityRepository<Document> repository;
        private readonly ResponseBuilder<DocumentIdentity, NewDocumentResponse> response_builder = new ResponseBuilder<DocumentIdentity, NewDocumentResponse>();
        private readonly IUnitOfWork unit_of_work;
        private Document document;
        private NewDocumentRequest request;
    }
}