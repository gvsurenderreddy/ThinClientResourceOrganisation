using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Remove
{
    public class RemoveMaritalStatusController
                    :   Controller
    {
        public RemoveMaritalStatusController( IRemoveMaritalStatus removeMaritalStatusCommand )
        {
            _removeMaritalStatus = Guard.IsNotNull( removeMaritalStatusCommand, "removeMaritalStatusCommand" );
        }

        public ActionResult SubmitRequest( RemoveMaritalStatusRequest removeMaritalStatusRequest )
        {
            var response = _removeMaritalStatus.execute( removeMaritalStatusRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IRemoveMaritalStatus _removeMaritalStatus;
    }
}