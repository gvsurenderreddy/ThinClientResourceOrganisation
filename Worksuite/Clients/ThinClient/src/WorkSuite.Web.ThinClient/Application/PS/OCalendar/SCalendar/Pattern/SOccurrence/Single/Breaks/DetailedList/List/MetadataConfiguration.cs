using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.List
{
    public class MetadataConfiguration
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<ShiftBreakDetails>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<ShiftBreakDetails> builder)
        {
            builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<ShiftBreakDetails> builder)
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