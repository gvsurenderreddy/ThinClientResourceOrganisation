using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Commands.Remove
{
    public class RemoveNationalityController
                            : Controller
    {
        public ActionResult SubmitRequest( RemoveNationalityRequest remove_nationality_request )
        {
            var response = _remove_nationality.execute( remove_nationality_request );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public RemoveNationalityController( IRemoveNationality remove_nationality )
        {
            _remove_nationality = Guard.IsNotNull( remove_nationality, "remove_nationality" );
        }

        private readonly IRemoveNationality _remove_nationality;
    }
}