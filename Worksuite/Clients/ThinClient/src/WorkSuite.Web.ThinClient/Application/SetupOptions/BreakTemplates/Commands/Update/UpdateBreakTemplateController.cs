using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Commands.Update
{
    public class UpdateBreakTemplateController
                        : Controller
    {
        public ActionResult SubmitRequest(UpdateBreakTemplateRequest the_update_break_template_request)
        {
            UpdateBreakTemplateResponse response = _update_break_template
                                                                .execute(the_update_break_template_request)
                                                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdateBreakTemplateController(IUpdateBreakTemplate the_update_break_template)
        {
            _update_break_template = Guard.IsNotNull(the_update_break_template,
                                                           "the_update_break_template"
                                                          );
        }

        private readonly IUpdateBreakTemplate _update_break_template;
    }
}