using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.DocumentStore;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents
{
    public class FakeDocumentRepository : FakeEntityRepository<Document, int>
    {
        public FakeDocumentRepository()
            : base(new IntIdentityProvider<Document>())
        {
        }
    }
}