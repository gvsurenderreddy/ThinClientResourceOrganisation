using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Commands.Create
{
    public class CreateEmployeeQualificationController
                        : Controller
    {
        public ActionResult SubmitRequest( NewEmployeeQualificationRequest the_new_employee_qualification_request )
        {
            var response = _assign_a_qualification_to_an_employee_command
                                    .execute( the_new_employee_qualification_request )
                                    ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public CreateEmployeeQualificationController( INewEmployeeQualification create_new_employee_qualification )
        {
            _assign_a_qualification_to_an_employee_command = Guard.IsNotNull( create_new_employee_qualification,
                "create_new_employee_qualification" );
        }

        private readonly INewEmployeeQualification _assign_a_qualification_to_an_employee_command;
    }
}