using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.GetAll;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.List
{
    public class EmployeeDocumentsListPresenter : Presenter
    {
        public ActionResult List(EmployeeIdentity employee)
        {

            var employee_documents = get_all.execute(employee);
            var view_model = list_builder.build(employee_documents.result, () => new { employee.employee_id });

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }


        public EmployeeDocumentsListPresenter(IGetAllEmployeeDocuments get_all_query
                                              , DetailsListBuilder<EmployeeDocumentDetails> the_list_builder)
        {

            Guard.IsNotNull(get_all_query, "get_all_query");
            Guard.IsNotNull(the_list_builder, "the_list_builder");

            get_all = get_all_query;
            list_builder = the_list_builder;
        }

        private readonly IGetAllEmployeeDocuments get_all;
        private readonly DetailsListBuilder<EmployeeDocumentDetails> list_builder;

    }
}