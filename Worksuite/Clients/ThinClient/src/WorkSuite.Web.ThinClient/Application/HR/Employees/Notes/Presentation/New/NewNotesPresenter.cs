using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.New
{
    public class NewNotesPresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {
            var new_request = new_note_request.execute(new EmployeeIdentity { employee_id = employee.employee_id });
            var view_model = editor_builder.build(new_request);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewNotesPresenter(IGetNewNoteRequest get_new_note_request
            , EditorBuilder<NewNoteRequest> the_editor_builder)
        {
            Guard.IsNotNull(get_new_note_request, "get_new_address_request");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            new_note_request = get_new_note_request;
            editor_builder = the_editor_builder;
        }


        private readonly IGetNewNoteRequest new_note_request;
        private readonly EditorBuilder<NewNoteRequest> editor_builder;
         
    }
}