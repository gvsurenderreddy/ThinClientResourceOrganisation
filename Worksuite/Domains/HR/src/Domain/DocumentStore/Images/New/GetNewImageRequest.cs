using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.New;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.New
{
    public class GetNewImageRequest : IGetNewImageRequest
    {
        public NewImageRequest execute(ImageIdentity request)
        {
            return new NewImageRequest
            {
                isDefault = true,
                data = new byte[0]
            };
        }
    }
}
