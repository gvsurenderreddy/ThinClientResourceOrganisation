using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.Editor
{
    public class NoteEditorPresenter : Presenter
    {
        private IGetUpdateRequest get_update_request;
        private EditorBuilder<UpdateRequest> editor_builder;

         public ActionResult Editor(NoteIdentity for_note)
        {
            var update_request = get_update_request.execute(for_note);
            var view_model = editor_builder.build(update_request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

         public NoteEditorPresenter(IGetUpdateRequest get_update_request_query
             , EditorBuilder<UpdateRequest> the_editor_builder)
       {
           Guard.IsNotNull(get_update_request_query, "get_update_request_query");
           Guard.IsNotNull(the_editor_builder, "the_editor_builder");

           get_update_request = get_update_request_query;
           editor_builder = the_editor_builder;
       }

    }
}