using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.GetAll;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.Page
{
    public class EmployeeDocumentsPresenter : Presenter
    {
        public ActionResult Page(EmployeeIdentity employee)
        {

            var view_model = builder
                                .For(employee)
                                .add_details_list(get_all.execute(employee).result, () => new { employee.employee_id })
                                .build();

            return View(@"~\Views\HR\Employees\EmployeeDocuments\Page.cshtml", view_model);

        }

        public EmployeeDocumentsPresenter(EmployeeDetailsViewModelBuilder the_view_model_builder, IGetAllEmployeeDocuments the_get_all)
        {
            builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
            get_all = Guard.IsNotNull(the_get_all, "the_get_all");
        }
        private readonly EmployeeDetailsViewModelBuilder builder;
        private readonly IGetAllEmployeeDocuments get_all;
    }
}