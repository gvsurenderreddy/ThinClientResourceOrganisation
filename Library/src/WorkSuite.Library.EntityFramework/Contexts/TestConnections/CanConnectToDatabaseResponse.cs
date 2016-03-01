using System.Data;
using System.Data.SqlClient;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections
{
    public class CanConnectToDatabaseResponse:ICanConnectToDatabase
    {
        public DatabaseConnectionTestResponse status { get; set; }
        public CanConnectToDatabaseResponse verify(string conection_string)
        {
            status_response = (TestConnectionString(conection_string))
                ? DatabaseConnectionTestResponse.ConnectionEstablished
                : DatabaseConnectionTestResponse.FailedToEstablishConnection;
            return new CanConnectToDatabaseResponse()
            {
                status = status_response
            };
        }
        private bool TestConnectionString(string connectionString)
        {

            var defulat_value = false;
            try
                {
                     var connection = new SqlConnection(connectionString);
                    var connetionstringResponse = Guard.IsNotNull(connection, "connection");
                    if (connetionstringResponse.State != ConnectionState.Open)
                    {
                        connection.Open();
                        defulat_value = connection.State == ConnectionState.Open;
                    }
                    else
                    {
                        connection.Close();
                    }
                }
         catch
           {
                return defulat_value;
           }
            return defulat_value;


        }
        private DatabaseConnectionTestResponse status_response;
    }
}