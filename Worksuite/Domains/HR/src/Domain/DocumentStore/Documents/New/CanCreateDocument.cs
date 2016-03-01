using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    public class CanCreateDocument : PermissionGranted<NewDocumentRequest>, ICanCreateDocument { }
}