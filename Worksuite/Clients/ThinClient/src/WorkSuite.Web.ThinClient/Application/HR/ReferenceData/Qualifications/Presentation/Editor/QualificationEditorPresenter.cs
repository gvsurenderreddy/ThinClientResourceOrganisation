using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.GetUpdateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.Editor
{
    public class QualificationEditorPresenter
                        :   Presenter
    {
        public QualificationEditorPresenter(IGetUpdateQualificationRequest updateQualificationRequest,
                                        EditorBuilder< UpdateQualificationRequest > theUpdateQualificationEditorBuilder
                                      )
        {
            _getUpdateQualificationRequest = Guard.IsNotNull( updateQualificationRequest, "updateQualificationRequest" );
            _updateQualificationEditorBuilder = Guard.IsNotNull( theUpdateQualificationEditorBuilder, "theUpdateQualificationEditorBuilder" );
        }

        public ActionResult Editor( ReferenceDataIdentity training )
        {
            var request = _getUpdateQualificationRequest.create(training);
            var viewModel = _updateQualificationEditorBuilder.build(request.result);

            return View( @"~\Views\Shared\Views\Editor.cshtml", viewModel );
        }

        private readonly IGetUpdateQualificationRequest _getUpdateQualificationRequest;
        private readonly EditorBuilder< UpdateQualificationRequest > _updateQualificationEditorBuilder;
    }
}