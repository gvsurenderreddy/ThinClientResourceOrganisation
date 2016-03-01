using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Details;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Presentation.Editor
{
    public class EmployeeImageEditorPresenter : Presenter
    {

        public ActionResult Editor(EmployeeImageDetails image)
        {
            var updateRequest = getUpdateRequest.execute(image);
            var viewModel = editorBuilder.build(updateRequest.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", viewModel);
        }

        public EmployeeImageEditorPresenter(IGetUpdateRequest getUpdateRequestQuery
             , EditorBuilder<UpdateRequest> theEditorBuilder)
       {
           Guard.IsNotNull(getUpdateRequestQuery, "getUpdateRequestQuery");
           Guard.IsNotNull(theEditorBuilder, "theEditorBuilder");

           getUpdateRequest = getUpdateRequestQuery;
           editorBuilder = theEditorBuilder;
       }

        private IGetUpdateRequest getUpdateRequest;
        private EditorBuilder<UpdateRequest> editorBuilder;
    }
}