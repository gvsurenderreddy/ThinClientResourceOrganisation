using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.Remove
{
    /// <summary>
    /// This remove documents service can remove 1 or more documents as passed in the request.
    /// </summary>
    public interface IRemoveManyDocuments 
                        : IResponseCommand<IEnumerable<DocumentIdentity>, RemoveManyDocumentsResponse> { }
}
