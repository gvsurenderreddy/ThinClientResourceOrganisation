using Humanizer;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmergencyContactDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmergencyContactDetails> model_metadata_builder)
        {
            model_metadata_builder
              .presenter_id( Resources.id )
              .id( m => m.emergency_contact_id.ToString() )
              .title( m => m.priority.Ordinalize() + " " + Resources.title.Humanize( LetterCasing.LowerCase ) )
              ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmergencyContactDetails> field_metadata_builder)
        {
            field_metadata_builder
              .for_field(m => m.name)
              .id(m => m.name)
              .is_included(m => !string.IsNullOrWhiteSpace(m.name))
              .label("Name")
              ;

            field_metadata_builder
              .for_field(m => m.relationship)
              .id(m => m.emergency_contact_id.ToString() + "relationship")
              .is_included(m => !string.IsNullOrWhiteSpace(m.relationship))
              .label("Relationship")
              ;

            field_metadata_builder
              .for_field(m => m.primary_phone_number)
              .id(m => m.emergency_contact_id.ToString() + "contact-1")
              .is_included(m => !string.IsNullOrWhiteSpace(m.primary_phone_number))
              .label(Page.Resources.page_field_primary_phone_number_label)
              ;

            field_metadata_builder
              .for_field(m => m.other_phone_number)
              .id(m => m.emergency_contact_id.ToString() + "contact-2")
              .is_included(m => !string.IsNullOrWhiteSpace(m.other_phone_number))
              .label(Page.Resources.page_field_other_phone_number_label)
              ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmergencyContactDetails> action_metadata_builder)
        {
            action_metadata_builder
                .add_action< Edit >()
                .id( Editor.Resources.id )
                .route_parameter_factory( m => new { m.emergency_contact_id } );


            action_metadata_builder
               .add_action< DetailsList.Remove >()
               .id( Commands.Remove.Resources.route_name )
               .route_parameter_factory( m => new { m.emergency_contact_id } )
               ;

            action_metadata_builder
                .add_action< DetailsList.Reorder >()
                .id( ReorderEditor.Resources.id )
                .route_parameter_factory( m => new { m.emergency_contact_id } );
                ;
        }
    }
}