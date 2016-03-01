using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Update
{
    public class UpdateMaritalStatusController
                        :   Controller
    {
        public UpdateMaritalStatusController( IUpdateMaritalStatus updateMaritalStatusCommand )
        {
            _updateMaritalStatus = Guard.IsNotNull( updateMaritalStatusCommand, "updateMaritalStatusCommand" );
        }

        public ActionResult SubmitRequest( UpdateMaritalStatusRequest updateMaritalStatusRequest )
        {
            var response = _updateMaritalStatus.execute( updateMaritalStatusRequest );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly IUpdateMaritalStatus _updateMaritalStatus;
    }
}