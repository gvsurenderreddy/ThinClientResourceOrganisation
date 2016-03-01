using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.addEmployee;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addEmployeeRequest.post
{
    public class AddEmployeeRequestController : Controller
    {
        public ActionResult Post(AddEmployeeRequest request)
        {
            var add_employee_response = add_employee.execute(request);

            var field_set_response = field_set_response_builder.build(add_employee_response);

            Response.StatusCode = field_set_response.has_errors ? 400 : 200;

            return Json(field_set_response, JsonRequestBehavior.AllowGet);
        }

        public AddEmployeeRequestController(IAddEmployeeRequestHandler add_employee
                                        , FieldSetValidationResponseBuilder<AddEmployeeResponse, EmployeeIdentity> field_set_response_builder)
        {

            this.add_employee = Guard.IsNotNull(add_employee, "add_employee");
            this.field_set_response_builder = Guard.IsNotNull(field_set_response_builder, "field_set_response_builder");
        }

        private readonly IAddEmployeeRequestHandler add_employee;
        private readonly FieldSetValidationResponseBuilder<AddEmployeeResponse, EmployeeIdentity> field_set_response_builder;
    }
}
