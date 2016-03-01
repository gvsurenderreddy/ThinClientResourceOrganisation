using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Formating;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.GetDetailsById;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.report;
using WTS.WorkSuite.Web.ThinClient.Infrastructure;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.get
{
    public class ShiftCalendarPatternsPagePresenter : PageIdentityPresenter<ShiftCalendarPatternPageIdentity>
    {
        public ActionResult page( ShiftCalendarPatternIdentity request )
        {
            return this
                      .set_request( request )
                      .add_pattern_details_to_view_model()
                      .add_resource_allocations_to_view_model()
                      .build_view()
                      ;
        }

        public ShiftCalendarPatternsPagePresenter ( ShiftCalendarPatternPageIdentity pattern_page_identity
                                             , ICurrentPageIdentityRepository current_page_identity_repository 
                                             , IGetShiftCalendarPatternDetailsById the_get_shift_calendar_pattern_details_by_id
                                             , AViewModelBuilder the_view_model_builder
                                             , IGetAllocatedResources the_get_allocated_resources
                                             ) 
             : base( pattern_page_identity, current_page_identity_repository )
        {
            get_shift_calendar_pattern_details_by_id = Guard.IsNotNull( the_get_shift_calendar_pattern_details_by_id,"the_get_shift_calendar_pattern_details_by_id" );
            view_model_builder = Guard.IsNotNull( the_view_model_builder, "the_view_model_builder" );
            get_allocated_resources = Guard.IsNotNull(the_get_allocated_resources, "the_get_allocated_resources");
        }


        private ShiftCalendarPatternsPagePresenter set_request( ShiftCalendarPatternIdentity request )
        {
            this.request = Guard.IsNotNull( request, "request");

            return this;
        }

        private ShiftCalendarPatternsPagePresenter add_pattern_details_to_view_model()
        {
            Guard.IsNotNull( request, "request" );

            var shift_calendar_pattern = get_shift_calendar_pattern_details_by_id.execute( request );

            var shift_calendar_report_details = new ShiftCalendarPatternReportDetails
            {
                operations_calendar_id = shift_calendar_pattern.result.operations_calendar_id,
                shift_calendar_id = shift_calendar_pattern.result.shift_calendar_id,
                shift_calendar_pattern_id = shift_calendar_pattern.result.shift_calendar_pattern_id,
                shift_calendar_pattern_name = shift_calendar_pattern.result.shift_calendar_pattern_name,
                actual_resource_allocated_against_requested = ReportFormatStringExtension.actual_against_requested_string_for_resource_allocation(shift_calendar_pattern.result.resource_allocation_summary, shift_calendar_pattern.result.number_of_resources)
            };

            view_model_builder.add_report( shift_calendar_report_details );
            return this;
        }

        private ShiftCalendarPatternsPagePresenter add_resource_allocations_to_view_model()
        {
            Guard.IsNotNull( request, "request" );

            var resource_details = get_allocated_resources.execute( request );
            view_model_builder.add_details_list( resource_details );
            return this;
        }

        private ActionResult build_view()
        {
            Guard.IsNotNull( request, "request" );

            var view_model = new EntityIdentityViewModel<ShiftCalendarPatternIdentity>
            {
                identity = request,
                view_elements = view_model_builder.build()
            };

            return View( @"~\Application\Ops\OpCalendars\PlannedSupply\ShiftCalendars\Patterns\viewPatterns\get\ShiftCalendarPatternsPage.cshtml", view_model );           
        }

        private readonly IGetShiftCalendarPatternDetailsById get_shift_calendar_pattern_details_by_id;
        private readonly AViewModelBuilder view_model_builder;
        private readonly IGetAllocatedResources get_allocated_resources;
        private ShiftCalendarPatternIdentity request;
    }
  
    public class ShiftCalendarPatternPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}