using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting
{
    public class FakeDatabaseConnectionTest
                    : ICanConnectToDatabase {


        public CanConnectToDatabaseResponse verify(string conection_string)
        {
            return new CanConnectToDatabaseResponse
            {
                
                status = response_status
            };
        }

        public DatabaseConnectionTestResponse response_status;
    }
}