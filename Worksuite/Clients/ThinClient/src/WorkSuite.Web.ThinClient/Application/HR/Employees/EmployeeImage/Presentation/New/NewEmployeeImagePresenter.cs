using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Service.HR.Employees;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Presentation.New
{
    public class NewEmployeeImagePresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {
            var newRequest = _newEmployeeImageRequest.execute(new EmployeeImageIdentity { employee_id = employee.employee_id});
            var viewModel = _editorBuilder.build(newRequest);

            return View(@"~\Views\Shared\Views\Editor.cshtml", viewModel);
        }

        public NewEmployeeImagePresenter
            (IGetNewEmployeeImageRequest getNewEmployeeImageRequest
            , EditorBuilder<NewEmployeeImageRequest> theEditorBuilder)
        {

            Guard.IsNotNull(getNewEmployeeImageRequest, "getNewEmployeeImageRequest");
            Guard.IsNotNull(theEditorBuilder, "theEditorBuilder");

            _newEmployeeImageRequest = getNewEmployeeImageRequest;
            _editorBuilder = theEditorBuilder;
        }

        private readonly IGetNewEmployeeImageRequest _newEmployeeImageRequest;
        private readonly EditorBuilder<NewEmployeeImageRequest> _editorBuilder;
    }
}