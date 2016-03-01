using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Commands.Update.Command.Update
{
    public class UpdateShifteTemplateDetailsController
                                   : Controller
    {
        public ActionResult SubmitRequest(UpdateShiftTemplateRequest request)
        {
            UpdateShiftTemplateResponse response = updtea_shift_template.execute(request);
            Response.StatusCode = response.has_errors ? 400 : 200;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdateShifteTemplateDetailsController
                                          (IUpdateShiftTemplate _update_shift_template)
        {
            updtea_shift_template = Guard.IsNotNull(_update_shift_template, "_update_shift_template");
        }

        private readonly IUpdateShiftTemplate updtea_shift_template;
    }
}