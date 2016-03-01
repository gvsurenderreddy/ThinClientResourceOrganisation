using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Create
{
    public class CreateMaritalStatusController
                            :   Controller
    {
        public CreateMaritalStatusController( ICreateMaritalStatus createMaritalStatusCommand )
        {
            _createMaritalStatus = Guard.IsNotNull( createMaritalStatusCommand, "createMaritalStatusCommand" );
        }

        public ActionResult SubmitRequest( CreateMaritalStatusRequest createMaritalStatusRequest )
        {
            var response = _createMaritalStatus.execute( createMaritalStatusRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly ICreateMaritalStatus _createMaritalStatus;
    }
}