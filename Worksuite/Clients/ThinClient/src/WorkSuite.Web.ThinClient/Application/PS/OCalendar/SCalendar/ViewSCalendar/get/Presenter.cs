using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Formating;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.GetDetailsById;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Queries.GetDetailsOfAllShiftCalendarPatterns;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.listReport;
using WTS.WorkSuite.Web.ThinClient.Infrastructure;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.Page
{
    public class ShiftCalendarPresenter : PageIdentityPresenter<ShiftCalendarPageIdentity>
    {
        public ActionResult Page(ShiftCalendarIdentity request)
        {
            var all_shift_calendar_patterns = _get_details_of_all_shift_calendar_patterns.execute(request).result.Select(scp=>new ShiftCalendarPatternListReportDetails()
            {
                 number_of_resources = scp.number_of_resources,
                 shift_calendar_pattern_name = scp.shift_calendar_pattern_name,
                 operations_calendar_id = scp.operations_calendar_id,
                 shift_calendar_id = scp.shift_calendar_id,
                 shift_calendar_pattern_id = scp.shift_calendar_pattern_id,
                 priority = scp.priority,
                 time_allocation_occurrences = scp.time_allocation_occurrences,
                 actual_resource_allocated_against_requested = ReportFormatStringExtension.actual_against_requested_string_for_resource_allocation(scp.resource_allocation_summary, scp.number_of_resources)
            });

            var shift_calendar_details = get_shift_calendar_details.execute(request);

            view_model_builder.add_report(shift_calendar_details.result)
                                            .add_details_list(all_shift_calendar_patterns)
                                            .build();

            var view_model = new EntityIdentityViewModel<ShiftCalendarIdentity>()
            {
                identity = request,
                view_elements = view_model_builder.build()
            };

            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\ShiftCalendar\Page.cshtml", view_model);
        }

        public ShiftCalendarPresenter(IGetDetailsOfAllShiftCalendarPatterns the_get_details_of_all_shift_calendar_patterns,
                                                        IGetShiftCalendarDetailsById the_get_shift_calendar_details,
                                                        AViewModelBuilder the_view_model_builder,
                                                        ShiftCalendarPageIdentity page_identity,
                                                        ICurrentPageIdentityRepository page_model_repository)
            : base(page_identity, page_model_repository)
        {
            _get_details_of_all_shift_calendar_patterns = Guard.IsNotNull(the_get_details_of_all_shift_calendar_patterns, "the_get_details_of_all_shift_calendar_patterns");

            get_shift_calendar_details = Guard.IsNotNull(the_get_shift_calendar_details, "the_get_shift_calendar_details");
            view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
        }

        private readonly IGetDetailsOfAllShiftCalendarPatterns _get_details_of_all_shift_calendar_patterns;
        private readonly IGetShiftCalendarDetailsById get_shift_calendar_details;
        private readonly AViewModelBuilder view_model_builder;
    }

    public class ShiftCalendarPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}