using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Commands.New.Command.Create
{
    public class CreateShiftTemplateController
                       :Controller
    {
        public ActionResult SubmitRequest
                                 (NewShiftTemplatesRequest request)
        {
            response = create_new_shift_template.execute(request);
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateShiftTemplateController
                                 (INewShiftTemplates create_new_shift_template_command)
        {
            create_new_shift_template = Guard.IsNotNull(create_new_shift_template_command, "create_new_shift_template_command");
        }

        private NewShiftTemplateResponse response;
        private readonly INewShiftTemplates create_new_shift_template;
    }
}