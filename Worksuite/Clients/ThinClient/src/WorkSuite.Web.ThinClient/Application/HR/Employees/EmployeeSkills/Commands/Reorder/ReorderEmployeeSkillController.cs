using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Commands.Reorder
{
    public class ReorderEmployeeSkillController
                            : Controller
    {
        public ReorderEmployeeSkillController(IReorderEmployeeSkill the_reorder_employee_skill_command)
        {
            _reorder_command = Guard.IsNotNull(the_reorder_employee_skill_command,
                "the_reorder_employee_skill_command");
        }

        public ActionResult SubmitRequest(ReorderEmployeeSkillRequest the_reorder_employee_skill_request)
        {
            var reorder_respone = _reorder_command.execute(the_reorder_employee_skill_request);

            Response.StatusCode = reorder_respone.has_errors ? 400 : 200;

            return Json(reorder_respone, JsonRequestBehavior.AllowGet);
        }

        private readonly IReorderEmployeeSkill _reorder_command;
    }
}