using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help
{
    public class FakeHelpUrlRepository
                 : FakeEntityRepository<HelpUrls, int>
    {
        public FakeHelpUrlRepository()
            : base(new IntIdentityProvider<HelpUrls>()) { }
   }
}