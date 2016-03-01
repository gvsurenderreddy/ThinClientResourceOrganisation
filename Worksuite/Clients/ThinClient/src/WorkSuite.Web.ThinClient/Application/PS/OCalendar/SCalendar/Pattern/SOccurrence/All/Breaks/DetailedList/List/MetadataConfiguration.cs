using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Presentation.List
{
    public class MetadataConfiguration
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<ShiftBreakDetailsForAllOccurrences>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<ShiftBreakDetailsForAllOccurrences> builder)
        {
            builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<ShiftBreakDetailsForAllOccurrences> builder)
        {
            builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.New>()
                .id(New.Resources.id)
                ;

            builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Edit>()
                .title("copy from template")
                .id(TemplateEditor.Resources.id)
                ;
        }
    }
}