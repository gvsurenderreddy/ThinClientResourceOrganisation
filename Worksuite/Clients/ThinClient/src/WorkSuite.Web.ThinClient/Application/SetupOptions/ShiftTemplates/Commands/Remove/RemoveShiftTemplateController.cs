using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Commands.Remove
{
    public class RemoveShiftTemplateController
                        : Controller 
    {

        public ActionResult SubmitRequest(ShiftTemplateIdentity shift_template_identity)
        {
            var response = remove_shift_template.execute(shift_template_identity);
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveShiftTemplateController(IRemoveShiftTemplate _remove_shift)
        {
            remove_shift_template = Guard.IsNotNull(_remove_shift, "_remove_shift");
        }

        private readonly IRemoveShiftTemplate remove_shift_template;
    }
}