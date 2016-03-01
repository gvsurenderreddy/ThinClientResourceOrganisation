using System.IO;

namespace WTS.WorkSuite.Library.EntityFramework.Contexts.ConnectionStringProviders {

    /// <summary>
    ///     <see cref="IConnectionStringProvider"/> that gets the connection string
    /// from the specified file.
    /// </summary
    /// <remarks>
    ///     The first line of the file is expected to be the connection string.
    /// </remarks>
    public class FileConnectionStringProvider 
                    : IConnectionStringProvider  {

        /// <summary>
        ///     The connection string that was read from the file.
        /// </summary>
        public string connection_string {
            get {
                using ( var reader = new StreamReader( file_path )) {
                    return reader.ReadLine();
                }                    
            }
        }


        public FileConnectionStringProvider 
                    ( string file_path ) {

            this.file_path = file_path;
        }

        private readonly string file_path;
    }
}