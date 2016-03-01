using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.viewSickness.get
{
    public class ViewSicknessPagePresenter : PageIdentityPresenter<ViewSicknessPageIdentity>
    {
        public ActionResult Page(EmployeeIdentity employee)
        {
            return this
                     .set_request(employee)
                     .get_sickness_details_list()
                     .build_view();
        }

        private ViewSicknessPagePresenter set_request(EmployeeIdentity employee)
        {
            this.request = employee;

            return this;
        }

        private ViewSicknessPagePresenter get_sickness_details_list()
        {
            Guard.IsNotNull(request, "request");

            list_response = get_employee_sickness_list_items.execute(request);

            return this;
        }

        private ActionResult build_view()
        {
            Guard.IsNotNull(request, "request");

            var new_view_model = new EmployeeIdentityViewModel()
            {
                identity = request,
                view_elements = builder.For(request)
                                .add_details_list(list_response.result)
                                .build()
            };

            return View(@"~\Application\HR\employee\Sickness\viewSickness\get\ViewSicknessPageView.cshtml", new_view_model);

        }

        public ViewSicknessPagePresenter(ViewSicknessPageIdentity pattern_page_identity, 
            ICurrentPageIdentityRepository current_page_identity_repository,
            EmployeeDetailsViewModelBuilder the_view_model_builder, 
            IGetSicknessListItems the_get_employee_sickness_list_items) : 
            base(pattern_page_identity, current_page_identity_repository)
        {
            builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
            get_employee_sickness_list_items = Guard.IsNotNull(the_get_employee_sickness_list_items, "the_get_employee_sickness_list_items");
        }


        private readonly EmployeeDetailsViewModelBuilder builder;
        private EmployeeIdentity request;
        private readonly IGetSicknessListItems get_employee_sickness_list_items;
        private GetSicknessListItemsResponse list_response;
    }

   
}