using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.Entity;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting {

    public class DatabaseSettingHelper
                    : EnityHelper<DatabaseSettings, int, DatabaseSettingBuilder,FakeDatabaseSettingRepository> { }
}
