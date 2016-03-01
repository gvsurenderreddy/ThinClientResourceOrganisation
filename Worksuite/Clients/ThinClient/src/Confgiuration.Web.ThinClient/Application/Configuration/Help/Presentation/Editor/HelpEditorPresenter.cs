using System.Web.Mvc;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Presentation.Editor
{
    public class HelpEditorPresenter
                  : Presenter
    {

        public ActionResult Editor()
        {
            var model = get_update_request.execute();
            var view_model = update_help_editor_builder.build(model);
            return View(@"~\Views\Shared\Views\Editor.cshtml",view_model);
        }

        public HelpEditorPresenter
                  ( EditorBuilder<UpdateHelpRequest> the_update_help_editor_builder 
                    ,IGetUpdateHelpRequest the_get_update_request)
        {
            update_help_editor_builder = Guard.IsNotNull(the_update_help_editor_builder, "the_update_help_editor_builder");
            get_update_request = Guard.IsNotNull(the_get_update_request, "the_get_update_request");
        }

        private readonly EditorBuilder<UpdateHelpRequest> update_help_editor_builder;
        private readonly IGetUpdateHelpRequest get_update_request;
    }
}