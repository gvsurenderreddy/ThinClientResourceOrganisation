using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.GetCreateRequest;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Presentation.New
{
    public class NewEthnicOriginPresenter
                        : Presenter
    {
        public ActionResult Editor()
        {
            var response = _get_create_ethnic_original_request.create();
            var view_model = _create_ethnic_original_editor_builder.build( response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public NewEthnicOriginPresenter(  IGetCreateEthnicOriginRequest get_create_ethnic_original_request,
                                            EditorBuilder< CreateEthnicOriginRequest > create_ethnic_original_editor_builder
                                         )
        {
            _get_create_ethnic_original_request = Guard.IsNotNull( get_create_ethnic_original_request, "get_create_ethnic_original_request" );
            _create_ethnic_original_editor_builder = Guard.IsNotNull( create_ethnic_original_editor_builder, "create_ethnic_original_editor_builder" );
        }

        public readonly IGetCreateEthnicOriginRequest _get_create_ethnic_original_request;
        public readonly EditorBuilder<CreateEthnicOriginRequest> _create_ethnic_original_editor_builder;
    }
}