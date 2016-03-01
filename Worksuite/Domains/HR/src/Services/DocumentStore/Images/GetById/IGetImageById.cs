using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Service.DocumentStore.Images.GetById
{
    public interface IGetImageById : IQuery<ImageIdentity, Response<byte[]>> { }
}
