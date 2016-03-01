using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Presentation.Editor
{
    public class EthnicOriginEditorPresenter
                        : Presenter
    {
        public ActionResult Editor( ReferenceDataIdentity ethnic_origin_identity )
        {
            var response = _get_update_ethnic_origin_request.create( ethnic_origin_identity );
            var view_model = _update_ethnic_origin_request_editor_builder.build( response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public EthnicOriginEditorPresenter( IGetUpdateEthnicOriginRequest get_update_ethnic_origin_request,
                                            EditorBuilder< UpdateEthnicOriginRequest > update_ethnic_origin_request_editor_builder
                                          )
        {
            _get_update_ethnic_origin_request = Guard.IsNotNull( get_update_ethnic_origin_request, "get_update_ethnic_origin_request" );
            _update_ethnic_origin_request_editor_builder = Guard.IsNotNull( update_ethnic_origin_request_editor_builder, "update_ethnic_origin_request_editor_builder" );
        }

        private readonly IGetUpdateEthnicOriginRequest _get_update_ethnic_origin_request;
        private readonly EditorBuilder< UpdateEthnicOriginRequest > _update_ethnic_origin_request_editor_builder;
    }
}