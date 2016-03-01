using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using DetailsList = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.List
{
    public class MetadataConfiguration
                    : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<BreakDetails>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<BreakDetails> builder)
        {
            builder
                .id(Resources.list_id)
                .title(Resources.list_title)
                .description(PlaceholderMessages.placeholder_05_0016)
                .presenter_id(Resources.route_name)
                ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<BreakDetails> builder)
        {
            builder
                .add_action<DetailsList.New>()
                .id(New.Resources.id)
                ;
        }
    }
}