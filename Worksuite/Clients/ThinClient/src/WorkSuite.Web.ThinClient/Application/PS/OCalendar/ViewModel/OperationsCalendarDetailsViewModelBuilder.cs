using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.View.ViewModel
{
    public class PlannedSupplyViewModelBuilder
    {
        public AViewModelBuilder For(GetOperationsCalendarAggregateOverRangeRequest the_operations_calendar)
        {
            var summary_response = _get_operations_calendar_summary.execute(the_operations_calendar);
            var builder = _a_view_model_builder
                .add_date_range_palette(summary_response.result)
                .add_simple_palette(summary_response.result)
                .add_content_header(summary_response.result)
                .add_date_range_bar(summary_response.result)
                .add_shift_calendars_lister(summary_response.result)
                ;

            return builder;
        }

        public PlannedSupplyViewModelBuilder(AViewModelBuilder the_view_model_builder,
                                                            IGetOperationsCalendarAggregateOverRange the_get_operations_calendar_summary
                                                        )
        {
            _a_view_model_builder = Guard.IsNotNull(the_view_model_builder,
                                                                    "the_view_model_builder"
                                                                 );
            _get_operations_calendar_summary = Guard.IsNotNull(the_get_operations_calendar_summary,
                                                                    "the_get_operations_calendar_summary"
                                                                 );
        }

        private readonly AViewModelBuilder _a_view_model_builder;
        private readonly IGetOperationsCalendarAggregateOverRange _get_operations_calendar_summary;
    }
}