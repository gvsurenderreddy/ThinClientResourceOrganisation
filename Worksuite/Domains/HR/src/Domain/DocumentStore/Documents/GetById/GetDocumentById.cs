using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.GetById
{
    public class GetDocumentById : IGetDocumentById
    {
        public GetDocumentById(IQueryRepository<Document> the_document_repository)
        {
            document_repository = Guard.IsNotNull(the_document_repository, "the_document_repository");
        }

        private readonly IQueryRepository<Document> document_repository;

        public GetDocumentByIdResponse execute(DocumentIdentity request)
        {
            var document = document_repository.Entities.Single(d => d.id == request.document_id);

            return new GetDocumentByIdResponse
            {
                result = new DocumentDetails
                {
                    name = document.name,
                    content_type = document.content_type,
                    data = document.data,
                    document_id = document.id,
                    md5_value = document.md5_value
                }
            };
        }
    }
}