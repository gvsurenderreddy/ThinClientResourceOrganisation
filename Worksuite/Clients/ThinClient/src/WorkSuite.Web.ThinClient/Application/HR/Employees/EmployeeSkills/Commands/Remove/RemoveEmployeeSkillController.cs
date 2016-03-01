using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Commands.Remove
{
    public class RemoveEmployeeSkillController : Controller
    {
        public ActionResult SubmitRequest(EmployeeSkillIdentity remove_request)
        {

            var remove_response = remove.execute(remove_request);

            Response.StatusCode = remove_response.has_errors ? 400 : 200;
            return Json(remove_response, JsonRequestBehavior.AllowGet);
        }


        public RemoveEmployeeSkillController(IRemoveEmployeeSkill remove_command)
        {
            remove = Guard.IsNotNull(remove_command, "remove_command");
        }

        private readonly IRemoveEmployeeSkill remove;
    }
}