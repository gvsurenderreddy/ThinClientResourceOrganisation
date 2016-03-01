using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help
{
    public class FakeUrlTest
    {
        public IsUrlExistReponse verify(string location_url)
        {
            return new IsUrlExistReponse()
            {
                status = response_status
            };
        }

        public UrlExistenceTestResponse response_status; 
    }
}