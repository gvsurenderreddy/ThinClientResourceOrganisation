using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Reorder
{
    public class ReorderAddressController : Controller
    {
        public ActionResult SubmitRequest(ReorderAddressRequest reorder_request)
        {
            var reorder_response = reorder.execute(reorder_request);

            Response.StatusCode = reorder_response.has_errors ? 400 : 200;

            return Json(reorder_response, JsonRequestBehavior.AllowGet);
        }


        public ReorderAddressController(IReorderAddress reorder_command)
        {

            reorder = Guard.IsNotNull(reorder_command, "reorder_command");

        }

        private readonly IReorderAddress reorder;
    }
}
