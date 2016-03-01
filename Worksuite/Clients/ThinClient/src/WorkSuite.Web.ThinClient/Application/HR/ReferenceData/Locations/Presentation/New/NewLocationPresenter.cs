using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.GetCreateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Presentation.New
{
    public class NewLocationPresenter
                    : Presenter
    {
        public ActionResult Editor()
        {
            var request = _get_create_location_request
                                .create()
                                ;

            var view_model = _create_location_request_editor_builder
                                .build(request.result)
                                ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewLocationPresenter(IGetCreateLocationRequest the_get_create_location_request,
                                    EditorBuilder<CreateLocationRequest> the_create_location_request_editor_builder
                                   )
        {
            _get_create_location_request = Guard.IsNotNull(the_get_create_location_request,
                                                           "the_get_create_location_request"
                                                          );
            _create_location_request_editor_builder = Guard.IsNotNull(the_create_location_request_editor_builder,
                                                                      "the_create_location_request_editor_builder"
                                                                     );
        }

        private readonly IGetCreateLocationRequest _get_create_location_request;
        private readonly EditorBuilder<CreateLocationRequest> _create_location_request_editor_builder;
    }
}