using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Commands.Create
{
    public class CreateBreakTemplateController
                        : Controller
    {
        public ActionResult SubmitRequest(NewBreakTemplateRequest the_new_break_template_request)
        {
            var response = _new_break_template
                                .execute(the_new_break_template_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateBreakTemplateController(INewBreakTemplate the_new_break_template)
        {
            _new_break_template = Guard.IsNotNull(the_new_break_template, "the_new_break_template");
        }

        private readonly INewBreakTemplate _new_break_template;
    }
}