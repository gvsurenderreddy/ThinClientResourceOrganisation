using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Commands.Remove
{
    public class RemoveBreakController
                    : Controller
    {
        public ActionResult SubmitRequest(BreakIdentity the_break_identity)
        {
            var response = _remove_break
                                .execute(the_break_identity)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveBreakController(IRemoveBreak the_remove_break)
        {
            _remove_break = Guard.IsNotNull(the_remove_break, "the_remove_break");
        }

        private readonly IRemoveBreak _remove_break;
    }
}