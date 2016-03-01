using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Service.DocumentStore.Images.Remove
{
    public interface IRemoveImage : IResponseCommand<ImageIdentity, RemoveImageResponse, ImageIdentity> { }

}
