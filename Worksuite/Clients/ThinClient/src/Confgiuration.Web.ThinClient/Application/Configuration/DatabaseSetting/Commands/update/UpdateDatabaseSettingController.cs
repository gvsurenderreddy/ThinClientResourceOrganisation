using System.Web.Mvc;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Commands.update
{
    public class UpdateDatabaseSettingController
                        :   Controller
    {
        public UpdateDatabaseSettingController 
                             (IUpdateDatabaseSettings the_update_database_settings)
        {
            update_database_settings = Guard.IsNotNull(the_update_database_settings, "the_update_database_settings");
        }

        public ActionResult SubmitRequest( UpdateDatabaseSettingRequest request )
        {
            var response = update_database_settings.execute(request);
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IUpdateDatabaseSettings update_database_settings;
    }
}