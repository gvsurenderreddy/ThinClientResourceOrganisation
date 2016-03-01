using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.details.Get
{

    public class EmployeeDetailsPagePresenter : PageIdentityPresenter<EmployeeDetailsPageIdentity>
    {

        public ActionResult Page
                             (EmployeeIdentity employee)
        {

            return View(
                    @"~\Application\HR\employee\details\Get\EmployeeDetailsPage.cshtml",
                    page_view_model_builder.build(employee));
        }


        public EmployeeDetailsPagePresenter
                (EmployeeDetailsPageViewModelBuilder page_view_model_builder
                    , EmployeeDetailsPageIdentity page_identity
                     , ICurrentPageIdentityRepository page_model_repository)
            : base(page_identity, page_model_repository)
        {

            this.page_view_model_builder = Guard.IsNotNull(page_view_model_builder, "page_view_model_builder");

        }

        private readonly EmployeeDetailsPageViewModelBuilder page_view_model_builder;


    }

    public class EmployeeDetailsPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}