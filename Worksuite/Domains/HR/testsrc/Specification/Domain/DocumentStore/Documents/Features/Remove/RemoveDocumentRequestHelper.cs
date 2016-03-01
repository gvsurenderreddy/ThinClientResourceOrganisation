using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.Remove
{
    public class RemoveDocumentRequestHelper : IRequestHelper<DocumentIdentity>
    {
        private readonly FakeDocumentRepository repository;

        public RemoveDocumentRequestHelper(FakeDocumentRepository the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_document_repository");
        }

        public DocumentIdentity given_a_valid_request()
        {
            var valid_document_data = DocumentHelper.valid_document();

            var document = new Document
            {
                content_type = "application/ms-word",
                data = valid_document_data,
                name = "A docx document"
            };

            repository.add(document);


            return new DocumentIdentity
            {
                document_id = document.id
            };
        }
    }
}