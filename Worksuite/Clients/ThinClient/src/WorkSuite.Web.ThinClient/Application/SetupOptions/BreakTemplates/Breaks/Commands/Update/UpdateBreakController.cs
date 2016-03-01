using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Commands.Update
{
    public class UpdateBreakController
                        : Controller
    {
        public ActionResult SubmitRequest(UpdateBreakRequest the_update_break_request)
        {
            var response = _update_break
                                .execute(the_update_break_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdateBreakController(IUpdateBreak the_update_break)
        {
            _update_break = Guard.IsNotNull(the_update_break, "the_update_break");
        }

        private readonly IUpdateBreak _update_break;
    }
}