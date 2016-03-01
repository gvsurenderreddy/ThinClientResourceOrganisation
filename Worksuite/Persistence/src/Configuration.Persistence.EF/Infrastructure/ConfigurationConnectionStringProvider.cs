using System;
using System.IO;
using System.Reflection;
using WTS.WorkSuite.Library.EntityFramework.Contexts.ConnectionStringProviders;

namespace Configuration.Persistence.EF.Infrastructure {

    // Improve: this has been put in place quite quicky to get round an deployment issue.
    // 
    //          A more considered approach needs to be put in place before this goes live, things 
    //          like sane handling of the file not begin there, performance considerations with
    //          regard every time a connection to the database is needed a file access will be made
    //          etc.

    /// <summary>
    ///     Provides the connection string for the Configuration context.  The connection
    /// string is retrieved from the worksuite_configuration_connection_string environment 
    /// variable.
    /// </summary>
    public class ConfigurationConnectionStringProvider
                    : FileConnectionStringProvider {

        /// <summary>
        ///     Hard coded to pass the name of the environment variable that holds
        /// the connection string to the base constructor 
        /// </summary>
        public ConfigurationConnectionStringProvider (  ) 
                : base( bin_directory() + @"\Infrastructure\ConfigurationConnectionString.txt" )  {}


        private static string bin_directory () {
            // Improve: This needs to be cleaned up and an explanation of what we are achieving provided.
            return new Uri( Path.GetDirectoryName( Assembly.GetExecutingAssembly().GetName().CodeBase ) ).LocalPath;
        }

    }
}