using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting {

    /// <summary>
    ///     Fake DatabaseSetting repository used instead or the real persistence layer
    /// for unit testing purposes.
    /// </summary>
    public class FakeDatabaseSettingRepository
                    : FakeEntityRepository<DatabaseSettings, int> {

        public FakeDatabaseSettingRepository()
            : base(new IntIdentityProvider<DatabaseSettings>()) { }

    }
}