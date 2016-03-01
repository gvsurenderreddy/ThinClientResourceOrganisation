using WorkSuite.Configuration.Service.Configuration.DatabaseSettings;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.GetCurrentDatabaseSetting;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Presentation.Report
{
    public class GetConnectioStringPresentationMetadata
        :Presenter
    {

        public GetCurrentDatabaseSettingResponse execute()
        {
            var response = get_Current_Database_Setting.execute();

            if (!response.has_errors && string.IsNullOrWhiteSpace(response.result.connection_string))
            {
                return new GetCurrentDatabaseSettingResponse
                {
                    result = new DatabaseSettingDetails()
                    {
                       connection_string = ErrorMessages.error_05_0004
                    },
                    messages = new ResponseMessage[]{}
                };
            }

            return response;
        }

        public GetConnectioStringPresentationMetadata
                         (IGetCurrentDatabaseSetting the_get_current_database_setting)
        {
            get_Current_Database_Setting = Guard.IsNotNull(the_get_current_database_setting, "the_get_current_database_setting");
        }

        private readonly IGetCurrentDatabaseSetting get_Current_Database_Setting;
    }
}