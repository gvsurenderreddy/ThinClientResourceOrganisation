using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Commands.Update
{
    public class UpdateNationalityController
                        : Controller
    {
        public ActionResult SubmitRequest( UpdateNationalityRequest update_nationality_request)
        {
            var response = _update_nationality.execute( update_nationality_request );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public UpdateNationalityController( IUpdateNationality update_nationality)
        {
            _update_nationality = Guard.IsNotNull( update_nationality, "update_nationality" );
        }

        private readonly IUpdateNationality _update_nationality;
    }
}