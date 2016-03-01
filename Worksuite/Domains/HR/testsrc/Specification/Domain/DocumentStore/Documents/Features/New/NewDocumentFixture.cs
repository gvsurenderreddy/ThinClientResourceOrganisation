using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.New
{
    public class NewDocumentFixture : ResponseCommandVerifiedByAnEntitiesStateFixture<NewDocumentRequest
        , NewDocumentResponse
        , INewDocument
        , Document>
    {


        public NewDocumentFixture(INewDocument the_command
                                , IRequestHelper<NewDocumentRequest> the_request_builder
                                , IEntityRepository<Document> the_repository)
            : base(the_command, the_request_builder)
        {
            repository = the_repository;
        }

        public override Document entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                return repository
                        .Entities
                        .Single(e => e.id == response.result.document_id)
                        ;
            }
        }

        private readonly IEntityRepository<Document> repository;
    }
}