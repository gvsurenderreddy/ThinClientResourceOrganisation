using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Commands.Remove
{
    public class RemoveQualificationController
                    :   Controller
    {
        public RemoveQualificationController(IRemoveQualification removeQualificationCommand)
        {
            _removeQualification = Guard.IsNotNull( removeQualificationCommand, "removeQualificationCommand" );
        }

        public ActionResult SubmitRequest( RemoveQualificationRequest removeQualificationRequest )
        {
            var response = _removeQualification.execute( removeQualificationRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IRemoveQualification _removeQualification;
    }
}