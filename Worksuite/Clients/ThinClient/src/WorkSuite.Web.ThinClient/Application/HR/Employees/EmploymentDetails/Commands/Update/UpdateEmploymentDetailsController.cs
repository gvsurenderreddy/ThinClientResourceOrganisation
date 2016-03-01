using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Commands.Update
{
    public class UpdateEmploymentDetailsController : Controller
    {
        public UpdateEmploymentDetailsController(   IUpdateEmploymentDetails updateEmploymentDetails )
        {
            _updateEmploymentDetails = Guard.IsNotNull( updateEmploymentDetails, "updateEmploymentDetails" );
        }

        public ActionResult SubmitRequest( UpdateEmploymentDetailsRequest updateEmploymentDetailsRequest )
        {
            var updateEmploymentDetailsResponse = _updateEmploymentDetails.execute( updateEmploymentDetailsRequest );

            Response.StatusCode = updateEmploymentDetailsResponse.has_errors ? 400 : 200;

            return Json( updateEmploymentDetailsResponse, JsonRequestBehavior.AllowGet );
        }

        private readonly IUpdateEmploymentDetails _updateEmploymentDetails;
    }
}