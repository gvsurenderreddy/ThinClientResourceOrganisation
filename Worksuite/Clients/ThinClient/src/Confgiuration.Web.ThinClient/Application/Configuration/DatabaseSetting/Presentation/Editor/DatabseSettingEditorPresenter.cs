using System.Web.Mvc;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Presentation.Editor
{

    public class DatabaseSettingEditorPresenter
                    : Presenter {


        public ActionResult Editor()
        {
            var model = get_update_request.execute();
            var view_model = update_database_setting_editor_builder.build(model);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model );
        }


        public DatabaseSettingEditorPresenter
                    ( EditorBuilder<UpdateDatabaseSettingRequest> the_Update_database_setting_editor_builder
                    , IGetUpdateRequest get_update_request_command )
        {
            update_database_setting_editor_builder = Guard.IsNotNull(the_Update_database_setting_editor_builder, "the_Update_database_setting_editor_builder");
            get_update_request = Guard.IsNotNull(get_update_request_command, "get_update_request_command");
        }

        private readonly EditorBuilder<UpdateDatabaseSettingRequest> update_database_setting_editor_builder;
        private readonly IGetUpdateRequest get_update_request;
                    }
}