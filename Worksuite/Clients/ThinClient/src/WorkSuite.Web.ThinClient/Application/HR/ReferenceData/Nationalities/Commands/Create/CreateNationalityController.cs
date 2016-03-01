using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Commands.Create
{
    public class CreateNationalityController
                        : Controller
    {
        public CreateNationalityController( ICreateNationality create_nationality_command )
        {
            _create_nationality = Guard.IsNotNull( create_nationality_command, "create_nationality_command" );
        }

        public ActionResult SubmitRequest( CreateNationalityRequest create_nationality_request )
        {
            var response = _create_nationality.execute( create_nationality_request );
            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        private readonly ICreateNationality _create_nationality;
    }
}