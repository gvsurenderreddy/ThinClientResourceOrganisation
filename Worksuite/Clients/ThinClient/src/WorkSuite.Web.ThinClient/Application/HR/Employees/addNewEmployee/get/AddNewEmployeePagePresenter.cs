using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.Employees.addEmployee;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.get;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addNewEmployee.page;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addNewEmployee.get
{

    public class AddNewEmployeePagePresenter : PageIdentityPresenter<AddNewEmployeePageIdentity>
    {
        public ActionResult Page()
        {
            var request = get_add_employee_request.execute().result;

            var view_model = editor_builder.build(request);

            return View(@"~\Application\HR\employees\addNewEmployee\page\AddNewEmployeePageView.cshtml", view_model);
        }

        public AddNewEmployeePagePresenter(IGetAddEmployeeRequestHandler get_add_employee_request,
                                        EditorBuilder<AddEmployeeRequest> editor_builder,
                                        AddNewEmployeePageIdentity page_identity,
                                        ICurrentPageIdentityRepository page_model_repository)
            : base(page_identity, page_model_repository)
        {

            Guard.IsNotNull(get_add_employee_request, "get_add_employee_request");
            Guard.IsNotNull(editor_builder, "editor_builder");

            this.get_add_employee_request = get_add_employee_request;
            this.editor_builder = editor_builder;
        }

        private readonly IGetAddEmployeeRequestHandler get_add_employee_request;
        private readonly EditorBuilder<AddEmployeeRequest> editor_builder;
    }

    public class AddNewEmployeePageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}