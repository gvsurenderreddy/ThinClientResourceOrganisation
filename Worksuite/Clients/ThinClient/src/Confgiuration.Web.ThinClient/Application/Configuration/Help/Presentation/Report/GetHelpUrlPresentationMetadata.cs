using WorkSuite.Configuration.Service.Configuration.Help;
using WorkSuite.Configuration.Service.Configuration.Help.GetCurrentHelpUrl;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Presentation.Report
{
    public class GetHelpUrlPresentationMetadata
                 : Presenter
    {
        public GetCurrentHelpUrlResponse execute()
        {
            var response = get_current_help_url.execute();
            if (!response.has_errors && string.IsNullOrWhiteSpace(response.result.location_url))
            {
                return new GetCurrentHelpUrlResponse()
                {
                    result = new HelpUrlDetails()
                    {
                        location_url = ErrorMessages.error_05_0013
                    },
                    messages = new ResponseMessage[] { }
                };
            }
            return response;
        }


        public GetHelpUrlPresentationMetadata
                       (IGetCurrentHelpUrl the_get_current_help_url)
        {
            get_current_help_url = Guard.IsNotNull(the_get_current_help_url, "the_get_current_help_url");
        }

        private readonly IGetCurrentHelpUrl get_current_help_url;
    }
}