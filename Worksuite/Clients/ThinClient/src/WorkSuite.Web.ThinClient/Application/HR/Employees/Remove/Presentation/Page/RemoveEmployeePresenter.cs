using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Remove;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Remove.Presentation.Page
{
    public class RemoveEmployeePresenter : Presenter
    {

        public RemoveEmployeePresenter
            (IGetRemoveEmployeeRequest getRemoveEmployeeRequest
            , EmployeeDetailsViewModelBuilder theViewNodelBuilder)
        {
            _getRemoveEmployeeRequest = Guard.IsNotNull(getRemoveEmployeeRequest, "get_remove_employee_request");
            _builder = Guard.IsNotNull(theViewNodelBuilder, "the_view_model_builder");
        }

        public ActionResult Page(EmployeeIdentity employee)
        {
            var response = _getRemoveEmployeeRequest.execute(employee).result;
            var view_model = _builder.For(employee)
                                        .add_editor(response)
                                        .build();

            var the_view_model = new EmployeeIdentityViewModel
            {
                identity = employee,
                view_elements = view_model
            };

            return View(@"~\Views\HR\Employees\Remove\Page.cshtml", the_view_model);
        }

        private readonly EmployeeDetailsViewModelBuilder _builder;

        private readonly IGetRemoveEmployeeRequest _getRemoveEmployeeRequest;

    }

}