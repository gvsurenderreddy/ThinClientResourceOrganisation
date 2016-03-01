using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Content.JsonContent
{
    public class ContentRepository : IContentRepository
    {
        public string get_resource_value(string resource_key)
        {
            try
            {
                return content_data[resource_key].value;
            }
            catch (KeyNotFoundException)
            {
                return string.Format("Error loading content with Key: {{ {0} }}", resource_key);
            }
        }

        public ContentRepository(IContentDataProvider content_data_provider)
        {
            Guard.IsNotNull(content_data_provider, "content_data_provider");

            content_data = Guard.IsNotNull(content_data_provider.get_content_data(), "content_data_provider.get_content_data()");
        }

        private readonly ContentData content_data;
    }
}
