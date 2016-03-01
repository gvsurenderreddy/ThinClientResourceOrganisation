using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.GetById
{
    public interface IGetDocumentById : IQuery<DocumentIdentity, GetDocumentByIdResponse> { }
}