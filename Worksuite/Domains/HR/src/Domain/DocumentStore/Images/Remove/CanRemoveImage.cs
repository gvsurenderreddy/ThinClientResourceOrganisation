using WTS.WorkSuite.Domain.Framework.Permissions;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.Remove;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.Remove
{
    public class CanRemoveImage : PermissionGranted<ImageIdentity>, ICanRemoveImage { }
}
