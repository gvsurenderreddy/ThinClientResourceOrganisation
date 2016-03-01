using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.New
{
    public class NewEmergencyContactPresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {
            var relationships = get_eligible_relationships
                            .execute(new EmergencyContactIdentity() { emergency_contact_id = NotSpecified.Id, employee_id = employee.employee_id })
                            .result
                            .Select(t => new LookupValue
                            {
                                id = t.id.ToString(CultureInfo.InvariantCulture),
                                description = t.description,
                            });

            var new_request = new_emergency_contact_request.execute(new EmployeeIdentity { employee_id = employee.employee_id });

            var view_model = editor_builder
                            .set_lookup_values(m => m.relationship_id, relationships)
                            .build(new_request);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewEmergencyContactPresenter
            (IGetNewEmergencyContactRequest get_new_emergency_contact_request
            , IGetDetailsOfRelationshipsEligibleForEmergencyContact the_get_eligible_relationships_query
            , EditorBuilder<NewEmergencyContactRequest> the_editor_builder)
        {

            Guard.IsNotNull(get_new_emergency_contact_request, "get_new_emergency_contact_request");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            get_eligible_relationships = Guard.IsNotNull(the_get_eligible_relationships_query, "the_get_eligible_relationships_query");

            new_emergency_contact_request = get_new_emergency_contact_request;
            editor_builder = the_editor_builder;
        }

        private readonly IGetDetailsOfRelationshipsEligibleForEmergencyContact get_eligible_relationships;
        private readonly IGetNewEmergencyContactRequest new_emergency_contact_request;
        private readonly EditorBuilder<NewEmergencyContactRequest> editor_builder;

    }
}