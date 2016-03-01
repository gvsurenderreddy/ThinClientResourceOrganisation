using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.GetUpdateRequest;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.Editor
{
    public class MaritalStatusEditorPresenter
                        :   Presenter
    {
        public MaritalStatusEditorPresenter(    IGetUpdateMaritalStatusRequest updateMaritalStatusRequest,
                                        EditorBuilder< UpdateMaritalStatusRequest > theUpdateMaritalStatusEditorBuilder
                                   )
        {
            _getUpdateMaritalStatusRequest = Guard.IsNotNull( updateMaritalStatusRequest, "updateMaritalStatusRequest" );
            _updateMaritalStatusEditorBuilder = Guard.IsNotNull( theUpdateMaritalStatusEditorBuilder, "theUpdateMaritalStatusEditorBuilder" );
        }

        public ActionResult Editor( ReferenceDataIdentity skill )
        {
            var request = _getUpdateMaritalStatusRequest.create( skill );
            var viewModel = _updateMaritalStatusEditorBuilder.build(request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", viewModel);
        }

        private readonly IGetUpdateMaritalStatusRequest _getUpdateMaritalStatusRequest;
        private readonly EditorBuilder< UpdateMaritalStatusRequest > _updateMaritalStatusEditorBuilder;
    }
}