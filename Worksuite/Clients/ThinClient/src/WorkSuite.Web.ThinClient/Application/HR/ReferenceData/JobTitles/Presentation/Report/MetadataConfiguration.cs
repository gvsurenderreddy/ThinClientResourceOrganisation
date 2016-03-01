﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.Report
{
    public class MetadataConfiguration
                    : ReportMetadataBuilder<JobTitleDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<JobTitleDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.id.ToString())
                .title(m => m.description)
                .is_marked_as_hidden(m => m.is_hidden)
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<JobTitleDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<JobTitleDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<Edit>()
                 .id(Editor.Resources.id)
                 .route_parameter_factory(m => new { m.id })
                 ;

            actions_metadata_builder
                 .add_action<DetailsList.Remove>()
                 .id(Commands.Remove.Resources.id)
                .route_parameter_factory(m => new { m.id })
                ;
        }
    }
}