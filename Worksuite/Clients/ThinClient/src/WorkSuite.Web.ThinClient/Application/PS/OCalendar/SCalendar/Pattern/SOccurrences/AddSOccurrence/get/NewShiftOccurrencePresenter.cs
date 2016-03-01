using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.New.Presentation.Page
{
    public class NewShiftOccurrencePresenter : PageIdentityPresenter<AddShiftPageIdentity>
    {
        public ActionResult Page(TimeBlockIdentity request)
        {
          
            var request1 = get_new_shift_Occurrence_request.execute(request);
            var view_model = editor_builder_request.build(request1);

            var the_view_model = new TimeBlockIdentityViewModel
            {
                identity = request,
                view_elements = new List<IsAViewElement>() { view_model }
            };

            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\ShiftOccurrence\New\Page.cshtml", the_view_model);
        }

        public NewShiftOccurrencePresenter(IGetNewShiftOccurrenceRequest the_query,
                                            EditorBuilder<NewShiftOccurrenceRequest> the_editor_builder_request, 
                                            AddShiftPageIdentity the_page_identity,
                                            ICurrentPageIdentityRepository the_page_model_repository)
            : base(the_page_identity, the_page_model_repository)
        {
            get_new_shift_Occurrence_request = Guard.IsNotNull(the_query, "the_query");
            editor_builder_request = Guard.IsNotNull(the_editor_builder_request, "the_editor_builder_request");
        }

        private readonly IGetNewShiftOccurrenceRequest get_new_shift_Occurrence_request;
        private readonly EditorBuilder<NewShiftOccurrenceRequest> editor_builder_request;
    }

    public class AddShiftPageIdentity : IPageIdentity
    {

        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}