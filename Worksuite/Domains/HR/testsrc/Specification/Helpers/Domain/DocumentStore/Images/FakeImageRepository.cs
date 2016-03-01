using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Service.Helpers.Framework.IdentityProvider;
using WTS.WorkSuite.Service.Helpers.Framework.Persistence;

namespace WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images
{
    public class FakeImageRepository : FakeEntityRepository<Image, int>
    {
        public FakeImageRepository ( ) : base( new IntIdentityProvider<Image>() ) {}
    }
}
