using WTS.WorkSuite.HR.HR.Employees.Notes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeNoteDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmployeeNoteDetails> model_metadata_builder)
        {
            model_metadata_builder
              .presenter_id(Resources.id)
              .id(m => m.note_id.ToString())
              ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeNoteDetails> field_metadata_builder)
        {
            field_metadata_builder
              .for_field(m => m.note)
              .id(m=>m.note_id.ToString() + "note")
              .label("Note")
              ;
            
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeNoteDetails> action_metadata_builder)
        {
            action_metadata_builder
                .add_action<Edit>()
                .id(Editor.Resources.id)
                .route_parameter_factory(m => new {m.note_id});


            action_metadata_builder
                .add_action<DetailsList.Remove>()
               .id(Commands.Remove.Resources.route_name)
               .route_parameter_factory(m => new { m.note_id })
               ;

        }
    }
}