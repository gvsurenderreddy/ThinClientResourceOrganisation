using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.AllResources.get;

namespace WTS.WorkSuite.Web.ThinClient.Application.Ops.OpCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.allResources.get
{
    public class AllResourcesPagePresenter : PageIdentityPresenter<ResourcesPageIdentity>
    {
        public ActionResult page( ShiftCalendarPatternIdentity request )
        {
            return this
                      .set_request( request )
                      .add_table_to_view_model( )
                      .build_view( );
        }

        public AllResourcesPagePresenter( ResourcesPageIdentity resources_page_identity
                                 , ICurrentPageIdentityRepository current_page_identity_repository
                                 , AllResourcesPageViewModelBuilder the_view_model_builder
                                 , IGetAllocatableResources the_get_allocatable_resources
                                 )
            : base( resources_page_identity, current_page_identity_repository )
        {
            view_model_builder = Guard.IsNotNull( the_view_model_builder, "the_view_model_builder" );
            get_allocatable_resources = Guard.IsNotNull( the_get_allocatable_resources, "the_get_allocatable_resources" );
        }

        private AllResourcesPagePresenter set_request( ShiftCalendarPatternIdentity request )
        {
            this.request = Guard.IsNotNull( request, "request" );

            return this;
        }

        private AllResourcesPagePresenter add_table_to_view_model( )
        {
            Guard.IsNotNull( request, "request" );

            var resource_details = get_allocatable_resources.execute( request );

            view_model_builder.add_table_list_element( resource_details );

            return this;
        }

        private ActionResult build_view( )
        {
            var view_model = view_model_builder.build( );

            return View(@"~\Application\Ops\OpCalendars\PlannedSupply\ShiftCalendars\Patterns\Allocations\AllResources\get\AllResourcesPage.cshtml", view_model);
        }

        private ShiftCalendarPatternIdentity request;

        private readonly AllResourcesPageViewModelBuilder view_model_builder;
        private readonly IGetAllocatableResources get_allocatable_resources;
    }


    public class ResourcesPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}