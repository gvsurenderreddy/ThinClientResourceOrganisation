using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Service.Helpers.Framework.Entity;
using WTS.WorkSuite.Service.Helpers.Framework.IdentityProvider;

namespace WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images
{
    public class ImageBuilder : IEntityBuilder<Image>
    {
        public ImageBuilder(Image theImage)
        {
            Guard.IsNotNull(theImage, "theImage");

            var imageIdentityProvider = new IntIdentityProvider<Image>();

            _Image = new Image
                {
                    id = imageIdentityProvider.next(),
                    data = theImage.data
                };
        }

        public Image entity { get { return _Image; } }

        public ImageBuilder withData(byte[] data)
        {
            _Image.data = data;
            return this;
        }

        private readonly Image _Image;
    }
}
