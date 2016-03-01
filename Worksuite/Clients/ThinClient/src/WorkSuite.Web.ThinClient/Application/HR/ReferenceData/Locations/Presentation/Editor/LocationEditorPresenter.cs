using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.GetUpdateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Presentation.Editor
{
    public class LocationEditorPresenter
                        : Presenter
    {
        public ActionResult Editor(ReferenceDataIdentity the_location)
        {
            var request = _get_update_location_request
                                .create(the_location)
                                ;

            var view_model = _update_location_request_editor_builder
                                .build(request.result)
                                ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public LocationEditorPresenter(IGetUpdateLocationRequest the_get_update_location_request,
                                       EditorBuilder<UpdateLocationRequest> the_update_location_request_editor_builder
                                      )
        {
            _get_update_location_request = Guard.IsNotNull(the_get_update_location_request,
                                                           "the_get_update_location_request"
                                                          );
            _update_location_request_editor_builder = Guard.IsNotNull(the_update_location_request_editor_builder,
                                                                      "the_update_location_request_editor_builder"
                                                                     );
        }

        private readonly IGetUpdateLocationRequest _get_update_location_request;
        private readonly EditorBuilder<UpdateLocationRequest> _update_location_request_editor_builder;
    }
}