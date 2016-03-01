using System.Linq;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.Helpers.Framework.Entity;

namespace WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images
{
    public class ImageHelper : EnityHelper<Image, int, ImageBuilder, FakeImageRepository, ImageIdentity>
    {
        public override Image get_enity_for(ImageIdentity identity)
        {
            return repository
                      .Entities
                      .Single(u => u.id == identity.imageId);
        }
    }
}
