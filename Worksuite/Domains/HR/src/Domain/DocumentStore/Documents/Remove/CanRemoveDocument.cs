using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.Remove
{
    public class CanRemoveDocument : PermissionGranted<DocumentIdentity>, ICanRemoveDocument { }
}