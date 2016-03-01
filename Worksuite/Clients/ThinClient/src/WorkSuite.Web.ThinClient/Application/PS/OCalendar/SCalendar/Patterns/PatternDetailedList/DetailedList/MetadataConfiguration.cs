using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.listReport;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.list
{
    public class MetadataConfiguration
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<ShiftCalendarPatternListReportDetails>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<ShiftCalendarPatternListReportDetails> builder)
        {
            builder
                .id(Resources.list_id)
                .title(Resources.list_title)
                .description(PlaceholderMessages.placeholder_05_0015)
                .is_sortable()
                ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<ShiftCalendarPatternListReportDetails> builder)
        {
            builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.New>()
                .id(PlannedSupply.ShiftCalendars.Patterns.newPattern.get.Resources.id)
                ;
        }
    }
}