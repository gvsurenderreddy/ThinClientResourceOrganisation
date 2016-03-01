using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.GetUpdateRequest;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.Editor
{
    public class NationalityEditorPresenter
                        : Presenter
    {
        public ActionResult Editor( ReferenceDataIdentity nationality_identity )
        {
            var response = _get_update_nationality_request.create( nationality_identity );
            var view_model = _update_nationality_request_editor_builder.build( response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public NationalityEditorPresenter(  IGetUpdateNationalityRequest get_update_nationality_request,
                                            EditorBuilder< UpdateNationalityRequest > update_nationality_request_editor_builder
                                         )
        {
            _get_update_nationality_request = Guard.IsNotNull( get_update_nationality_request,
                "get_update_nationality_request" );
            _update_nationality_request_editor_builder = Guard.IsNotNull( update_nationality_request_editor_builder,
                "update_nationality_request_editor_builder" );
        }

        private readonly IGetUpdateNationalityRequest _get_update_nationality_request;
        private readonly EditorBuilder< UpdateNationalityRequest > _update_nationality_request_editor_builder;
    }
}