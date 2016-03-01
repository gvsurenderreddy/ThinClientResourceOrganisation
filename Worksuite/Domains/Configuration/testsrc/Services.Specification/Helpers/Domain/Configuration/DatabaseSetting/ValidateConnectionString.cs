using System;
using System.Data;
using System.Data.SqlClient;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting
{
    public class ValidateConnectionString :ICanConnectToDatabase
    {
        public DatabaseConnectionTestResponse status { get; set; }
        
        public CanConnectToDatabaseResponse verify(string conection_string)
        {
            stat_Response = (TestconnectionString(conection_string))
                ? DatabaseConnectionTestResponse.ConnectionEstablished
                : DatabaseConnectionTestResponse.FailedToEstablishConnection;

           return new CanConnectToDatabaseResponse()
            {
                status = stat_Response
            };
        }
      private bool TestconnectionString(string connectionString)
        {
            bool isValid = true;
                        using (var conn = new SqlConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();
                                if (conn.State != ConnectionState.Open)
                                {
                                    isValid = false;
                                }
                            }
                            catch 
                            {
                                isValid = false;
                            }
                        }
            
                        return isValid;
        }
        private DatabaseConnectionTestResponse stat_Response;
    }
}