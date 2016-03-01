using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent {

    /// <summary>
    ///     Fake static Content repository used instead or the real persistence layer
    /// for unit testing purposes.
    /// </summary>
    public class FakeStaticContentRepository
                    : FakeEntityRepository<StaticContents, int> {

        public FakeStaticContentRepository()
            : base(new IntIdentityProvider<StaticContents>()) { }

    }
}