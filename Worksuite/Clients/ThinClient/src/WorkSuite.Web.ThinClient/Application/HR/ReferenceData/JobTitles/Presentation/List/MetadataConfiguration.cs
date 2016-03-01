using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.List
{
    public class MetadataConfiguration
                    : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<JobTitleDetails>
    {
        protected override void build_list_metadata
                                    (IDetailsListMetadataBuilder<JobTitleDetails> builder)
        {
            builder
                .id(Resources.list_id)
                .title(Resources.list_title)
                .presenter_id(Resources.route_name)
                ;
        }

        protected override void build_list_actions_metadata
                                    (IDetailsListActionsMetadataBuilder<JobTitleDetails> builder)
        {
            builder
                .add_action<DetailsList.New>()
                .id(New.Resources.id)
                ;
        }
    }
}