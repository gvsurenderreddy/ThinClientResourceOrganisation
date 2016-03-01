using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.Editor
{
    public class EmergencyContactEditorPresenter : Presenter
    {
        private readonly IGetDetailsOfRelationshipsEligibleForEmergencyContact get_eligible_relationships;
        private IGetUpdateRequest get_update_request;
        private EditorBuilder<UpdateRequest> editor_builder;


        public ActionResult Editor(EmergencyContactIdentity request)
        {
            var relationships = get_eligible_relationships
                            .execute(new EmergencyContactIdentity() { emergency_contact_id = request.emergency_contact_id, employee_id = request.employee_id })
                            .result
                            .Select(t => new LookupValue
                            {
                                id = t.id.ToString(CultureInfo.InvariantCulture),
                                description = t.description,
                            });


            var update_request = get_update_request.execute(request);
            var view_model = editor_builder.set_lookup_values(m => m.relationship_id, relationships)
                                            .build(update_request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public EmergencyContactEditorPresenter(IGetUpdateRequest get_update_request_query
                                            , EditorBuilder<UpdateRequest> the_editor_builder
                                            , IGetDetailsOfRelationshipsEligibleForEmergencyContact the_get_eligible_relationships_query)
        {
            Guard.IsNotNull(get_update_request_query, "get_update_request_query");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            get_eligible_relationships = Guard.IsNotNull(the_get_eligible_relationships_query, "the_get_eligible_relationships_query");

            get_update_request = get_update_request_query;
            editor_builder = the_editor_builder;
        }

    }
}