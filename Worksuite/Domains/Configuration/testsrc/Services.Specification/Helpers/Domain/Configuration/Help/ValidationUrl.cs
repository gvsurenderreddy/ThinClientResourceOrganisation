using System;
using System.Net;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help
{
    public class ValidationUrl
    {
        public UrlExistenceTestResponse status { get; set; }

        public IsUrlExistReponse verify(string location_url)
        {
            status_response = (validate_url(location_url))
                ? UrlExistenceTestResponse.UrlEstablished
                : UrlExistenceTestResponse.FailedToEstablishUrl;
            return new IsUrlExistReponse()
            {
                status = status_response
            };
        }

        private bool validate_url(string field_value)
        {
            const bool result = false;
            if (Uri.IsWellFormedUriString(field_value, UriKind.Absolute))
            {
                var request = (HttpWebRequest)WebRequest.Create(field_value);
                request.Method = "Get";
                var response = request.GetResponse() as HttpWebResponse;

                return (response != null && response.StatusCode == HttpStatusCode.OK &&
                        response.StatusDescription != null);
            }
            return result;
        }
        private UrlExistenceTestResponse status_response; 
    }
}