using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Commands.Remove
{
    public class RemoveBreakTemplateController
                        : Controller
    {
        public ActionResult SubmitRequest(BreakTemplateIdentity the_remove_break_template)
        {
            var response = _remove_break_template
                                .execute(the_remove_break_template)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveBreakTemplateController(IRemoveBreakTemplate the_remove_break_template)
        {
            _remove_break_template = Guard.IsNotNull(the_remove_break_template,
                                                           "the_remove_break_template"
                                                          );
        }

        private readonly IRemoveBreakTemplate _remove_break_template;
    }
}