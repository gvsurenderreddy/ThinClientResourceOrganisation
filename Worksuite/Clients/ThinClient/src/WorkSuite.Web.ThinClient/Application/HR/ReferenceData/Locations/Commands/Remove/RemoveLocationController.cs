using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Commands.Remove
{
    public class RemoveLocationController
                        : Controller
    {
        public ActionResult SubmitRequest(RemoveLocationRequest the_remove_location_request)
        {
            var response = _remove_location
                                .execute(the_remove_location_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveLocationController(IRemoveLocation the_remove_location)
        {
            _remove_location = Guard.IsNotNull(the_remove_location, "the_remove_location");
        }

        private readonly IRemoveLocation _remove_location;
    }
}