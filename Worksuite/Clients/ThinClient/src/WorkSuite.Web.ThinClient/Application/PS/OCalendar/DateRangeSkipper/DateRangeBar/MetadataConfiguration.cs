using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.DateRangeBar
{
    public class MetadataConfiguration : DateRangeBarDefinitionsBuilder<OperationsCalendarAggregateOverRange>
    {
        protected override void build_model_definitions(DynamicDateRangeBarStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> model_definitions_builder)
        {
            model_definitions_builder
                            .start_date(m => m.start_date)
                            .date_range(m => m.range_returned);
        }
    }
}