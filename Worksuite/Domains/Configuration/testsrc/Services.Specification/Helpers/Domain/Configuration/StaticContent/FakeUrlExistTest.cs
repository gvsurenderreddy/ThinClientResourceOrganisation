using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent
{
    public class FakeUrlExistTest
                 : IcheckUrlExist
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