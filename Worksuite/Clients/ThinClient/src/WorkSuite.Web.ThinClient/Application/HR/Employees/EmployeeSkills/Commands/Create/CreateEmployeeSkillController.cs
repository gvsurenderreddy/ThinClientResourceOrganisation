using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Commands.Create
{
    public class CreateEmployeeSkillController : Controller
    {
        public ActionResult SubmitRequest(NewEmployeeSkillRequest create_request)
        {

            // to do: validate the update_request that was built from the request.

            var update_response = create.execute(create_request);

            Response.StatusCode = update_response.has_errors ? 400 : 200;

            return Json(update_response, JsonRequestBehavior.AllowGet);

        }

        public CreateEmployeeSkillController(INewEmployeeSkill create_command)
        {
            Guard.IsNotNull(create_command, "create_command");

            create = create_command;
        }

        private readonly INewEmployeeSkill create;
    }
}