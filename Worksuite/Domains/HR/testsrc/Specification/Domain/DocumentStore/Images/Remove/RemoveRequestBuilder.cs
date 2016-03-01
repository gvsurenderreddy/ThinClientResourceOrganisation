using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images;
using WTS.WorkSuite.Service.Helpers.Framework.Request;

namespace WTS.WorkSuite.Service.Domain.DocumentStore.Images.Remove
{
    public class RemoveRequestBuilder : IRequestBuilder<ImageIdentity>
    {
        private readonly FakeImageRepository repository;

        public RemoveRequestBuilder(FakeImageRepository the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_image_repository");
        }

        public ImageIdentity given_a_valid_request()
        {

            var image = new Image
            {
                data = new byte[] { },
                isDefault = false

            };

            repository.add(image);

            return new ImageIdentity()
            {
                imageId = image.id
            };
        }
    }
}
