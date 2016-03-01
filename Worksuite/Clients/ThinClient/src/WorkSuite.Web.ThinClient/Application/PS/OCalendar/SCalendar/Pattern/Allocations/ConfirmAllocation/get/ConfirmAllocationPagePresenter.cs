using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.get;
using WTS.WorkSuite.Web.ThinClient.Infrastructure;

namespace WTS.WorkSuite.Web.ThinClient.Application.Ops.OpCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.confirmAllocation.get
{
    public class ConfirmAllocationPagePresenter : PageIdentityPresenter<ConfirmAllocationPageIdentity>
    {
        public ActionResult page( GetAllocateEmployeePatternRequest request )
        {
            return this
                      .set_request( request )
                      .get_request_details( )
                      .build_view( );
        }

        public ConfirmAllocationPagePresenter( ConfirmAllocationPageIdentity confirm_allocation_page_identity
                                         , ICurrentPageIdentityRepository current_page_identity_repository
                                         , EditorBuilder<AllocationRequestDetails> editor_builder
                                         , IGetAllocationRequestDetails get_allocation_request_details )
            : base(confirm_allocation_page_identity, current_page_identity_repository)
        {
            this.editor_builder = Guard.IsNotNull(editor_builder, "editor_builder");
            this.get_allocation_request_details = Guard.IsNotNull(get_allocation_request_details, "get_allocation_request_details");
        }

        private ConfirmAllocationPagePresenter set_request(GetAllocateEmployeePatternRequest request)
        {
            this.request = Guard.IsNotNull( request, "request" );

            return this;
        }

        private ConfirmAllocationPagePresenter get_request_details( )
        {
            Guard.IsNotNull( request, "request" );

            allocation_request_details = get_allocation_request_details.execute( request );

            return this;
        }

        private ActionResult build_view()
        {
            var the_view_model = editor_builder.build( allocation_request_details );

            var view_model = new EntityIdentityViewModel<GetAllocateEmployeePatternRequest>
            {
                identity = request,
                view_elements = new List<IsAViewElement>() { the_view_model }
            };

            return View( @"~\Application\Ops\OpCalendars\PlannedSupply\ShiftCalendars\Patterns\Allocations\ConfirmAllocation\get\ConfirmAllocationPage.cshtml", view_model );
        }

        private readonly IGetAllocationRequestDetails get_allocation_request_details;
        private readonly EditorBuilder<AllocationRequestDetails> editor_builder;

        private AllocationRequestDetails allocation_request_details;
        private GetAllocateEmployeePatternRequest request;

    }

    public class ConfirmAllocationPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}