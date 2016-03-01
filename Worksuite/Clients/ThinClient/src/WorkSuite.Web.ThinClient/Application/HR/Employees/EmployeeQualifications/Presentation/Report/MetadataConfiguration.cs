using System.Globalization;
using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.Report
{
    public class MetadataConfiguration
                        : ReportMetadataBuilder< EmployeeQualificationDetails >
    {
        protected override void build_model_metadata( IReportModelMetadataBuilder< EmployeeQualificationDetails > model_metadata_builder )
        {
            model_metadata_builder
                .presenter_id( Resources.id )
                .id( m => m.employee_qualification_id.ToString() )
                ;
        }

        protected override void build_field_metadata( IReportFieldsMetadataBuilder< EmployeeQualificationDetails > fields_metadata_builder )
        {
            fields_metadata_builder
                .for_field( fm => fm.qualification )
                .id( fm => fm.employee_qualification_id.ToString( CultureInfo.InvariantCulture ) + "-qualification" )
                .is_included( fm => !string.IsNullOrWhiteSpace( fm.qualification ) )
                ;
        }

        protected override void build_action_metadata( IReportActionsMetadataBuilder< EmployeeQualificationDetails > actions_metadata_builder )
        {
            actions_metadata_builder
                .add_action< global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove >()
                .id( Commands.Remove.Resources.route_name )
                .route_parameter_factory( m => new { m.employee_qualification_id } )
                ;
        }
    }
}