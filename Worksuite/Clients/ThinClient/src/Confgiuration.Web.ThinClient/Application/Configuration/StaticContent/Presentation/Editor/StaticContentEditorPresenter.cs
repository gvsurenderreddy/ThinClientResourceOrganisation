using System.Web.Mvc;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Presentation.Editor
{
    public class StaticContentEditorPresenter
                 :Presenter{

        public ActionResult Editor()
        {
            var model = get_update_request.execute();
            var view_model = updateStaticContentEditorBuilder.build(model);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public StaticContentEditorPresenter
                                (EditorBuilder<UpdateStaticContentRequest> _updateStaticContentEditorBuilder
                                ,IGetUpdateStaticContentRequest _get_update_request)
        {
            updateStaticContentEditorBuilder = _updateStaticContentEditorBuilder;
            get_update_request = Guard.IsNotNull(_get_update_request, "_get_update_request");
        }

        private readonly EditorBuilder<UpdateStaticContentRequest> updateStaticContentEditorBuilder;
        private readonly IGetUpdateStaticContentRequest get_update_request;

                 }
}