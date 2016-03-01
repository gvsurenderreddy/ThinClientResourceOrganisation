using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.ReorderEditor
{
    public class ReorderEmergencyContactEditorPresenter
                            : Presenter
    {
        public ReorderEmergencyContactEditorPresenter(  IGetReorderEmergencyContactRequest the_get_reorder_emergency_contact_request,
                                                        EditorBuilder<ReorderEmergencyContactDetails> the_reorder_emergency_contact_editor_builder
                                                     )
        {
            _get_reorder_request = Guard.IsNotNull( the_get_reorder_emergency_contact_request,
                "the_get_reorder_emergency_contact_request" );
            _editor_builder = Guard.IsNotNull( the_reorder_emergency_contact_editor_builder,
                "the_reorder_emergency_contact_editor_builder" );
        }

        public ActionResult Editor( ReorderEmergencyContactRequest the_reorder_emergency_contact_request )
        {
            var update_emergency_contact_request = _get_reorder_request.execute( the_reorder_emergency_contact_request );
            var view_model = _editor_builder.build( update_emergency_contact_request.result );

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        private readonly IGetReorderEmergencyContactRequest _get_reorder_request;
        private readonly EditorBuilder<ReorderEmergencyContactDetails> _editor_builder;
    }
}