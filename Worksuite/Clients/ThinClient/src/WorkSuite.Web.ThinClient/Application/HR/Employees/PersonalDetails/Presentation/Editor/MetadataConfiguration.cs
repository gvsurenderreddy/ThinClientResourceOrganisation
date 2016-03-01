using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetails.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<UpdateEmployeePersonalDetailsRequest>
    {
        protected override void build_model_metadata
            (IEditorModelMetadataBuilder<UpdateEmployeePersonalDetailsRequest> builder)
        {
            builder
                .title("Edit " + PersonalDetailsResources.title.ToLower())
                .id(Resources.id)
                ;
        }

        protected override void build_field_metadata
            (IEditorFieldsMetadataBuilder<UpdateEmployeePersonalDetailsRequest> builder)
        {
            builder
                .for_field(m => m.forename)
                .id("forename")
                .label("Forename")
                .is_required(true)
                ;

            builder
                .for_field(m => m.othername)
                .id("othername")
                .label("Other names")
                ;

            builder
                .for_field(m => m.surname)
                .id("surname")
                .label("Surname")
                .is_required(true)
                ;

            builder
                .for_field(m => m.gender_id)
                .id("gender_id")
                .label("Gender")
                .is_lookup()
                .help("Gender can be added, edited or removed from the 'setup menus' options on the home page.")
                ;

            builder
                .for_field(m => m.marital_status_id)
                .id("marital_status_id")
                .label("Marital status")
                .is_lookup()
                .help("Marital status can be added, edited or removed from the 'setup menus' options on the home page.")
                ;

            builder
                .for_field(m => m.nationality_id)
                .id("nationality_id")
                .label("Nationality")
                .is_lookup()
                .help("Nationality can be added, edited or removed from the 'setup menus' options on the home page.")
                ;

            builder
                .for_field(m => m.birth_place)
                .id("birth_place")
                .label("Place of birth")
                ;

            builder
                .for_field( m => m.date_of_birth )
                .label( "Date of birth" )
                .is_composed()
                .help("Please enter a valid date using the format (Day/Month/Year). Day and year fields should be entered as numerics, the month may be entered as characters or numerics.")
                ;

            builder
                .for_field(m => m.ethnic_origin_id)
                .id("ethnic_origin_id")
                .label("Ethnic origin")
                .is_lookup()
                .help("Ethnic origin can be added, edited or removed from the 'setup menus' options on the home page.")
                ;

            builder
                .for_field(m => m.employee_id)
                .id("employee_id")
                .is_hidden()
                ;

            // to do: this is temporary until fields default to excluded and are excluded
            builder
                .for_field(m => m.title_id)
                .id("title_id")
                .label("Title")
                .is_lookup()
                .help("Titles can be added, edited or removed from the 'setup menus' options on the home page.")
                ;
        }

        protected override void build_action_metadata
            (IEditorActionsMetadataBuilder<UpdateEmployeePersonalDetailsRequest> builder)
        {
            // to do: add actions after it has been built
            builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
                .route_parameter_factory(m => new { m.employee_id })
                ;

            builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}