using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.editor
{
    public class ConfirmAllocationEditorDefinition : EditorMetadataBuilder<AllocationRequestDetails>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<AllocationRequestDetails> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<AllocationRequestDetails> fields_metadata_builder)
        {
            fields_metadata_builder
               .for_field(sc => sc.name)
               .id("employee_name")
               .label("Name")
               .is_readonly()
               ;

            fields_metadata_builder
               .for_field(sc => sc.employee_reference)
               .id("employee_reference")
               .label("Employee reference")
               .is_readonly()
               ;

            fields_metadata_builder
               .for_field(sc => sc.location)
               .id("location")
               .label("Location")
               .is_readonly()
               .is_included(e => !string.IsNullOrEmpty(e.location))
               ;

            fields_metadata_builder
               .for_field(sc => sc.job_title)
               .id("job_title")
               .label("Job title")
               .is_readonly()
               .is_included(e => !string.IsNullOrEmpty(e.job_title))
               ;
           
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<AllocationRequestDetails> actions_metadata_builder)
        {

            actions_metadata_builder
               .add_action<SubmitEdit>()
               .call_to_action<PrimaryCallToAction>()
               .id(post.Resources.id)
               .route_parameter_factory(r => new { r.operations_calendar_id, r.shift_calendar_id , r.shift_calendar_pattern_id , r.employee_id })
               ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;


           
        }
    }
}