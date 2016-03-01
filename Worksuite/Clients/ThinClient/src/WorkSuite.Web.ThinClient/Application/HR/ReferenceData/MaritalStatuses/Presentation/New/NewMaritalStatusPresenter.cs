using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.GetCreateRequest;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.New
{
    public class NewMaritalStatusPresenter
                        :   Presenter
    {
        public NewMaritalStatusPresenter(   IGetCreateMaritalStatusRequest getNewMaritalStatusRequest,
                                    EditorBuilder< CreateMaritalStatusRequest > theNewMaritalStatusEditorBuilder
                                )
        {
            _newMaritalStatusRequest = Guard.IsNotNull( getNewMaritalStatusRequest, "getNewMaritalStatusRequest" );
            _newMaritalStatusEditorBuilder = Guard.IsNotNull( theNewMaritalStatusEditorBuilder, "theNewMaritalStatusEditorBuilder" );
        }

        public ActionResult Editor()
        {
            var response = _newMaritalStatusRequest.create();
            var viewModel = _newMaritalStatusEditorBuilder.build( response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", viewModel );
        }

        public readonly IGetCreateMaritalStatusRequest _newMaritalStatusRequest;
        public readonly EditorBuilder< CreateMaritalStatusRequest > _newMaritalStatusEditorBuilder;
    }
}