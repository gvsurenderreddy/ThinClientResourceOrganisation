using System.Web.Mvc;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Command.Update
{
    public class UpdateHelpController
                 : Controller
    {
        public UpdateHelpController(IUpdateHelp the_update_help)
        {
            _update_help = Guard.IsNotNull(the_update_help, "the_update_help");
        }

        public ActionResult SubmitRequest(UpdateHelpRequest request)
        {
            var response = _update_help.execute(request);
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private readonly IUpdateHelp _update_help;

    }
}



