using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.GetCreateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.New
{
    public class NewQualificationPresenter
                        :   Presenter
    {
        public NewQualificationPresenter(   IGetCreateQualificationRequest getNewQualificationRequest,
                                            EditorBuilder< CreateQualificationRequest > theNewQualificationEditorBuilder
                                        )
        {
            _newQualificationRequest = Guard.IsNotNull(getNewQualificationRequest, "getNewQualificationRequest");
            _newQualificationEditorBuilder = Guard.IsNotNull(theNewQualificationEditorBuilder, "theNewQualificationEditorBuilder");
        }

        public ActionResult Editor()
        {
            var response = _newQualificationRequest.create();
            var viewModel = _newQualificationEditorBuilder.build(response.result);

            return View( @"~\Views\Shared\Views\Editor.cshtml", viewModel );
        }

        private readonly IGetCreateQualificationRequest _newQualificationRequest;
        private readonly EditorBuilder<CreateQualificationRequest> _newQualificationEditorBuilder;
    }
}