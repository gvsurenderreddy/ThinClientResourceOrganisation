using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Commands.Create
{
    public class CreateBreakController
                    : Controller
    {
        public ActionResult SubmitRequest(NewBreakRequest the_new_break_request)
        {
            var response = _new_break
                                .execute(the_new_break_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateBreakController(INewBreak the_new_break)
        {
            _new_break = Guard.IsNotNull(the_new_break, "the_new_break");
        }

        private readonly INewBreak _new_break;
    }
}