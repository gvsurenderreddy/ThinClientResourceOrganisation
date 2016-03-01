using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.DateRangePalette.Component
{
    public class MetadataConfiguration : DateRangePaletteDefinitionsBuilder<DateRangePaletteRequest>
    {
        protected override void build_model_definitions(DynamicDateRangePaletteStaticDefinitionBuilder<DateRangePaletteRequest> model_definitions_builder)
        {
            model_definitions_builder
                            .title("Date Range")
                            .selected_start_date(m => m.selected_date)
                            .calendar_start_date(m => m.calendar_start_date)
                            .selected_range(m => m.range_type);
        }

        protected override void build_actions_definitions(DynamicDateRangePaletteActionsStaticDefinitionBuilder<DateRangePaletteRequest> actions_definitions_builder)
        {
            actions_definitions_builder
                .new_action<ToggleWeek>()
                .add()
                ;

            actions_definitions_builder
                .new_action<ToggleFourWeeks>()
                .add()
                ;
        }
    }
}