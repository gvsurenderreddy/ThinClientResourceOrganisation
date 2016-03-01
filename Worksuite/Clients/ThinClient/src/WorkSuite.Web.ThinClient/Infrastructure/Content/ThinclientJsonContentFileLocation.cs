using System;
using System.IO;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.Content
{
    public class ThinclientJsonContentFileLocation : IContentFileLocation
    {
        public string file_path
        {
            get
            {
                return Path.Combine(
                    assembly_directory_name_uri().LocalPath
                    , "json_content_store_en.json"
                    );
                     
            }
            
        }

        private Uri assembly_directory_name_uri()
        {
            return new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
        }
    }
}
