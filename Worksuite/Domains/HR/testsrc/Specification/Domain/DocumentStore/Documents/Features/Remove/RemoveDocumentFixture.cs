using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.Remove
{
    public class RemoveDocumentFixture
                    : ResponseCommandFixture<DocumentIdentity, RemoveDocumentResponse, IRemoveDocument>
    {

        public RemoveDocumentFixture(IRemoveDocument the_command
            , IRequestHelper<DocumentIdentity> the_request_builder)

            : base(the_command, the_request_builder)
        {

        }


    }
}