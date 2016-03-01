using WorkSuite.Configuration.Service.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Configuration.StaticContent.GetCurrentStaticContent;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Presentation.Report
{
    public class GetLocationUrlPresentationMetadata
        :Presenter
    {

        public GetCurrentStaticContentResponse execute()
        {
            var response = get_current_static_content.execute();
            if (!response.has_errors && string.IsNullOrWhiteSpace( response.result.location_url))
            {
             
                return new GetCurrentStaticContentResponse()
                {
                    result = new StaticContentDetails {
                        location_url = ErrorMessages.error_05_0005
                    },
                    messages = new ResponseMessage[]{}
                };

            }
            return response;
        }

      
        public GetLocationUrlPresentationMetadata(IGetCurrentStaticContent _get_current_Static_content)
        {
            get_current_static_content = _get_current_Static_content;
        }
        private IGetCurrentStaticContent get_current_static_content;

    }
}