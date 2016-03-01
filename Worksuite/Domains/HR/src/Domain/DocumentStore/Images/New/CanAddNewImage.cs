using WTS.WorkSuite.Domain.Framework.Permissions;
using WTS.WorkSuite.Service.DocumentStore.Images.New;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.New
{
    public class CanAddNewImage : PermissionGranted<NewImageRequest>, ICanAddNewImage {}
}
