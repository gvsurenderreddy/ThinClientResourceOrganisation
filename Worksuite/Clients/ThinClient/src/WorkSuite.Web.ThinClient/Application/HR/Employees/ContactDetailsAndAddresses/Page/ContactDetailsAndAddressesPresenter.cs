using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetAll;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.ById;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetailsAndAddresses.Page
{
    public class ContactDetailsAndAddressesPresenter
                        : Presenter
    {
        public ActionResult Page(EmployeeIdentity employee)
        {
            var view_model = _view_model_builder
                                .For(employee)
                                    .add_report(_get_contact_details_query.execute(employee).result)
                                    .add_details_list(_get_all_addresses_query.execute(employee).result, () => new { employee.employee_id })
                                .build()
                                ;

            return View(@"~\Views\HR\Employees\ContactDetailsAndAddresses\Page.cshtml", view_model);
        }

        public ContactDetailsAndAddressesPresenter(IGetContactDetailsById the_get_contact_details_query,
                                                   IGetAllAddresses the_get_all_addresses_query,
                                                   EmployeeDetailsViewModelBuilder the_view_model_builder
                                                  )
        {
            _get_contact_details_query = Guard.IsNotNull(the_get_contact_details_query, "the_get_contact_details_query");
            _get_all_addresses_query = Guard.IsNotNull(the_get_all_addresses_query, "the_get_all_addresses_query");
            _view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
        }

        private readonly IGetContactDetailsById _get_contact_details_query;
        private readonly IGetAllAddresses _get_all_addresses_query;
        private readonly EmployeeDetailsViewModelBuilder _view_model_builder;
    }
}