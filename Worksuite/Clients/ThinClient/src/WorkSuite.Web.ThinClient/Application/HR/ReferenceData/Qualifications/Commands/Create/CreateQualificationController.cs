using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Commands.Create
{
    public class CreateQualificationController
                        :   Controller
    {
        public CreateQualificationController(ICreateQualification createQualificationCommand)
        {
            _createQualification = Guard.IsNotNull( createQualificationCommand, "createQualificationCommand" );
        }

        public ActionResult SubmitRequest( CreateQualificationRequest createQualificationRequest )
        {
            var response = _createQualification.execute( createQualificationRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly ICreateQualification _createQualification;
    }
}