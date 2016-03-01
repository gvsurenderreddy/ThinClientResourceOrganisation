using WTS.WorkSuite.Service.Framework.Permissions;

namespace WTS.WorkSuite.Service.DocumentStore.Images.Remove
{
    public interface ICanRemoveImage : IExecutePermission<ImageIdentity> { }

}
