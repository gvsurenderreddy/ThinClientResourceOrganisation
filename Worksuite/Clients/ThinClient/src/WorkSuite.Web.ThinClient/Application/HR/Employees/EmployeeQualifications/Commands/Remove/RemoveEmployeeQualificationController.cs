using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Commands.Remove
{
    public class RemoveEmployeeQualificationController
                        : Controller
    {
        public ActionResult SubmitRequest( EmployeeQualificationIdentity the_remove_employee_qualification_request )
        {
            RemoveEmployeeQualificationResponse response = _remove_employee_qualification_command
                                                                    .execute( the_remove_employee_qualification_request )
                                                                    ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public RemoveEmployeeQualificationController( IRemoveEmployeeQualification the_remove_employee_qualificaton_command )
        {
            _remove_employee_qualification_command = Guard.IsNotNull( the_remove_employee_qualificaton_command,
                "the_remove_employee_qualificaton_command" );
        }

        private readonly IRemoveEmployeeQualification _remove_employee_qualification_command;
    }
}