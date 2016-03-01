using System;
using System.IO;
using Newtonsoft.Json;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Content.JsonContent
{
    public class ContentDataFromJsonFileProvider : IContentDataProvider
    {
        public ContentData get_content_data()
        {
            Guard.IsNotNull(content_data, "content_data");

            return content_data;
        }

        public ContentDataFromJsonFileProvider(IContentFileLocation content_file_location)
        {
            Guard.IsNotNull(content_file_location, "content_file_location");

            try
            {
                var file_contents = read_contents_from_file(content_file_location.file_path);

                content_data = JsonConvert.DeserializeObject<ContentData>(file_contents);
            }
            catch (Exception)
            {
                //Todo: Log/Report problem with reading data

                content_data = new ContentData();
            }
        }

        private string read_contents_from_file(string file_path)
        {
            string content_string;

            using (var reader = new StreamReader(file_path))
            {
                content_string = reader.ReadToEnd();
            }

            return content_string;
        }

        private readonly ContentData content_data;
    }
}
