using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Commands.Remove
{
    public class RemoveEthnicOriginController
                        : Controller
    {
        public ActionResult SubmitRequest( RemoveEthnicOriginRequest remove_ethnic_origin_request )
        {
            var response = _remove_ethnic_origin.execute( remove_ethnic_origin_request );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public RemoveEthnicOriginController( IRemoveEthnicOrigin remove_ethnic_origin )
        {
            _remove_ethnic_origin = Guard.IsNotNull( remove_ethnic_origin, "remove_ethnic_origin" );
        }

        private readonly IRemoveEthnicOrigin _remove_ethnic_origin;
    }
}