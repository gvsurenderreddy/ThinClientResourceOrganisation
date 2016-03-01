using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.New
{
    public class NewEmployeeDocumentPresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {

            var new_request = new_employee_document_request.execute(new EmployeeIdentity { employee_id = employee.employee_id });

            var view_model = editor_builder
                            .build(new_request);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewEmployeeDocumentPresenter
            (IGetNewEmployeeDocumentRequest get_new_employee_document_request
            , EditorBuilder<NewEmployeeDocumentRequest> the_editor_builder)
        {

            Guard.IsNotNull(get_new_employee_document_request, "get_new_employee_document_request");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            new_employee_document_request = get_new_employee_document_request;
            editor_builder = the_editor_builder;
        }

        private readonly IGetNewEmployeeDocumentRequest new_employee_document_request;
        private readonly EditorBuilder<NewEmployeeDocumentRequest> editor_builder;

    }
}