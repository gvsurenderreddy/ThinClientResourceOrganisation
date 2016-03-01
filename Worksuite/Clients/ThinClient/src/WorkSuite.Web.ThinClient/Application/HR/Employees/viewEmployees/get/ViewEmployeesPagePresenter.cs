using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.viewEmployees.get
{

    public class ViewEmployeesPagePresenter : PageIdentityPresenter<ViewEmployeesPageIdentity>
    {


        public ActionResult Page()
        {

            // improve: error handling needs to be applied.

            var result_set = get_all_employees.execute();
            var view_model = view_model_builder.build(result_set.result);

            return View(@"~\Application\HR\Employees\viewEmployees\get\ViewEmployeesPageView.cshtml", view_model);
        }


        public ViewEmployeesPagePresenter
                                        (IGetAllEmployeeDetails get_all_employees
                                        , ViewEmployeesPageViewModelBuilder view_model_builder
                                        , ViewEmployeesPageIdentity page_identity
                                        , ICurrentPageIdentityRepository page_model_repository)
            : base(page_identity, page_model_repository)
        {


            this.get_all_employees = Guard.IsNotNull(get_all_employees, "get_all_employees");
            this.view_model_builder = Guard.IsNotNull(view_model_builder, "view_model_builder");
        }

        private readonly IGetAllEmployeeDetails get_all_employees;
        private readonly ViewEmployeesPageViewModelBuilder view_model_builder;
    }

    public class ViewEmployeesPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}