using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetails.Presentation.Editor
{

    public class ContactDetailsEditorPresenter : Presenter 
    {
        private IGetUpdateRequest get_update_request;
        private EditorBuilder<UpdateRequest> editor_builder;

        public ContactDetailsEditorPresenter
            (IGetUpdateRequest get_update_request_query
            , EditorBuilder<UpdateRequest> the_editor_builder)
        {

            Guard.IsNotNull(get_update_request_query, "get_update_request_query");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            get_update_request = get_update_request_query;
            editor_builder = the_editor_builder;
        }

        public ActionResult Editor ( EmployeeIdentity for_employee ) 
        {
            var update_request = get_update_request.execute( for_employee );
            var view_model = editor_builder.build( update_request.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }



    }
}
