using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.New
{
    public class NewAddressPresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {
            var new_request = new_address_request.execute(new EmployeeIdentity { employee_id = employee.employee_id });
            var view_model = editor_builder.build(new_request);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewAddressPresenter
            (IGetNewAddressRequest get_new_address_request
            , EditorBuilder<NewAddressRequest> the_editor_builder)
        {

            Guard.IsNotNull(get_new_address_request, "get_new_address_request");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            new_address_request = get_new_address_request;
            editor_builder = the_editor_builder;
        }

        private readonly IGetNewAddressRequest new_address_request;
        private readonly EditorBuilder<NewAddressRequest> editor_builder;
         
    }
}