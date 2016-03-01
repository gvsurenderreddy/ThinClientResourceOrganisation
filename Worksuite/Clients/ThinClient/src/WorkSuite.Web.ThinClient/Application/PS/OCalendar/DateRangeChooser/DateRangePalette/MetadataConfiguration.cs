using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.DateRangePalette
{
    public class MetadataConfiguration : DateRangePaletteDefinitionsBuilder<OperationsCalendarAggregateOverRange>
    {
        protected override void build_model_definitions(DynamicDateRangePaletteStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> model_definitions_builder)
        {
            model_definitions_builder
                            .title("Date Range")
                            .selected_start_date(m => m.start_date)
                            .calendar_start_date(m => m.start_date)
                            .selected_range(m => m.range_returned);
        }

        protected override void build_actions_definitions(DynamicDateRangePaletteActionsStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> actions_definitions_builder)
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