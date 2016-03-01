using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    public interface INewDocumentValidator
    {
        IEnumerable<ResponseMessage> validate(NewDocumentRequest request); 
    }
}