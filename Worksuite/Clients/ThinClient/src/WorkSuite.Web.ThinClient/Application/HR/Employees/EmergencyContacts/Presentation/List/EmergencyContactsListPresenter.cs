using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetAll;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.List
{
    public class EmergencyContactsListPresenter : Presenter
    {
        public ActionResult List(EmployeeIdentity employee)
        {

            var emergency_contacts = get_all.execute(employee);
            var view_model = list_builder.build(emergency_contacts.result, () => new { employee.employee_id });

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }


        public EmergencyContactsListPresenter(IGetAllEmergencyContacts get_all_query
                                              , DetailsListBuilder<EmergencyContactDetails> the_list_builder)
        {

            Guard.IsNotNull(get_all_query, "get_all_query");
            Guard.IsNotNull(the_list_builder, "the_list_builder");

            get_all = get_all_query;
            list_builder = the_list_builder;
        }

        private readonly IGetAllEmergencyContacts get_all;
        private readonly DetailsListBuilder<EmergencyContactDetails> list_builder;

    }
}