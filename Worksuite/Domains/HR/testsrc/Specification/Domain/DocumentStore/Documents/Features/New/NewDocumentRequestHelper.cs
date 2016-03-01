using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.New
{
    public class NewDocumentRequestHelper : IRequestHelper<NewDocumentRequest>
    {

        public NewDocumentRequest given_a_valid_request()
        {
            var valid_document_data = DocumentHelper.valid_document();

            return new NewDocumentRequest
            {
                content_type = "application/ms-word",
                data = valid_document_data,
                name = "A docx document"
            };
        }
    }
}