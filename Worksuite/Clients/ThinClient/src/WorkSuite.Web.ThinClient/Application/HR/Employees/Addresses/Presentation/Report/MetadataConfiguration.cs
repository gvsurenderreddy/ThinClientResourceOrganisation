using Humanizer;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<AddressDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<AddressDetails> model_metadata_builder)
        {
            model_metadata_builder
               .presenter_id( Resources.id )
               .id( m => m.address_id.ToString() )
               .title (m => m.priority.Ordinalize() + " " + Resources.title.Humanize( LetterCasing.LowerCase ) )
               ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<AddressDetails> field_metadata_builder)
        {
            field_metadata_builder
               .for_field(m => m.lines)
               .id(a => a.address_id + "address1")
               .label("House number or name")
               ;

            field_metadata_builder
               .for_field(m => m.county)
               .id(a=>a.address_id + "county")
               .is_included( m => !string.IsNullOrWhiteSpace(m.county) )
               .label("County")
               ;

            field_metadata_builder
               .for_field(m => m.country)
               .id(a => a.address_id + "country")
               .is_included(m => !string.IsNullOrWhiteSpace(m.country))
               .label("Country")
               ;

            field_metadata_builder
              .for_field(m => m.postcode)
              .id(a=>a.address_id + "postcode")
              .label("Postcode")
              ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<AddressDetails> action_metadata_builder)
        {
            action_metadata_builder
                .add_action<Edit>()
                .id(Editor.Resources.id)
                .route_parameter_factory(m => new { m.address_id })
                ;

            action_metadata_builder
                .add_action<DetailsList.Remove>()
               .id(Commands.Remove.Resources.route_name)
               .route_parameter_factory(m => new { m.address_id })
               ;

            action_metadata_builder
                .add_action<DetailsList.Reorder>()
               .id(ReorderEditor.Resources.id)
               .route_parameter_factory(m => new { m.address_id })
               ;
        }
    }
}