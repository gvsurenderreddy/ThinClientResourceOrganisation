using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Commands.Update
{
    public class UpdateEthnicOriginController
                        : Controller
    {
        public ActionResult SubmitRequest( UpdateEthnicOriginRequest update_ethnic_origin_request )
        {
            var response = _update_ethnic_origin.execute( update_ethnic_origin_request );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public UpdateEthnicOriginController( IUpdateEthnicOrigin update_ethnic_origin )
        {
            _update_ethnic_origin = Guard.IsNotNull( update_ethnic_origin, "update_ethnic_origin" );
        }

        private readonly IUpdateEthnicOrigin _update_ethnic_origin;
    }
}