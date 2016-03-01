using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Commands.Update
{
    public class UpdateQualificationController
                        :   Controller
    {
        public UpdateQualificationController( IUpdateQualification updateQualificationCommand )
        {
            _updateQualificationRequest = Guard.IsNotNull( updateQualificationCommand, "updateQualificationCommand" );
        }

        public ActionResult SubmitRequest( UpdateQualificationRequest updateQualificationRequest )
        {
            var response = _updateQualificationRequest.execute( updateQualificationRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IUpdateQualification _updateQualificationRequest;
    }
}