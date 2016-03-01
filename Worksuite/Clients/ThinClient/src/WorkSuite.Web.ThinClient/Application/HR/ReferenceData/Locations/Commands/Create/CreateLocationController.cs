using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Commands.Create
{
    public class CreateLocationController
                    : Controller
    {
        public ActionResult SubmitRequest(CreateLocationRequest the_create_location_request)
        {
            var response = _create_location
                                .execute(the_create_location_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateLocationController(ICreateLocation the_create_location)
        {
            _create_location = Guard.IsNotNull(the_create_location, "the_create_location");
        }

        private readonly ICreateLocation _create_location;
    }
}