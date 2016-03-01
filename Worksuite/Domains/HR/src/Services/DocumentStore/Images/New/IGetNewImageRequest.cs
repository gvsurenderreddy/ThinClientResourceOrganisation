using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Service.DocumentStore.Images.New
{
    public interface IGetNewImageRequest : ICommand<ImageIdentity, NewImageRequest> {}
}
