using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Commands.Create
{
    public class CreateEthnicOriginController
                        : Controller
    {
        public ActionResult SubmitRequest( CreateEthnicOriginRequest create_ethnic_original_request )
        {
            var response = _create_ethnic_original.execute( create_ethnic_original_request );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public CreateEthnicOriginController( ICreateEthnicOrigin create_ethnic_original )
        {
            _create_ethnic_original = Guard.IsNotNull( create_ethnic_original, "create_ethnic_original" );
        }

        private readonly ICreateEthnicOrigin _create_ethnic_original;
    }
}