using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish.IGetPublishShiftCalendarRequest;
using WTS.WorkSuite.Web.ThinClient.Infrastructure;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Presentation.Publish.Get
{
    public class ShiftCalendarPublishEditorPresenter : PageIdentityPresenter<ShiftCalendarPublishPageIdentity>
    {
        private readonly IGetPublishShiftCalendarRequest get_publish_request;
        private readonly EditorBuilder<PublishShiftCalendarRequest> editor_builder_request;

        public ShiftCalendarPublishEditorPresenter(ShiftCalendarPublishPageIdentity pattern_page_identity, 
            ICurrentPageIdentityRepository current_page_identity_repository
             , IGetPublishShiftCalendarRequest the_get_publish_request
                                             , EditorBuilder<PublishShiftCalendarRequest> the_editor_builder_request) 
            : base(pattern_page_identity, current_page_identity_repository)
        {
            get_publish_request = Guard.IsNotNull(the_get_publish_request, "the_get_publish_request");
            editor_builder_request = Guard.IsNotNull(the_editor_builder_request, "the_editor_builder_request");
        }

        public ActionResult Page(ShiftCalendarIdentity request)
        {
            var request_result = get_publish_request.execute(request).result;
            var view_model = editor_builder_request.build(request_result);

            var the_view_model = new EntityIdentityViewModel<ShiftCalendarIdentity>
            {
                identity = request,
                view_elements = new List<IsAViewElement>() { view_model }
            };
      
            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\Publish\Page.cshtml", the_view_model);
        }
    }

     public class ShiftCalendarPublishPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }

}