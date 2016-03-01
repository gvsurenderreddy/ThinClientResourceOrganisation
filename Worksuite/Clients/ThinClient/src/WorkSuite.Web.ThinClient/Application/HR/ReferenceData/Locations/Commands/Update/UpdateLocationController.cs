using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Commands.Update
{
    public class UpdateLocationController
                    : Controller
    {
        public ActionResult SubmitRequest(UpdateLocationRequest the_update_location_request)
        {
            var response = _update_location
                                .execute(the_update_location_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdateLocationController(IUpdateLocation the_update_location)
        {
            _update_location = Guard.IsNotNull(the_update_location, "the_update_location");
        }

        private readonly IUpdateLocation _update_location;
    }
}