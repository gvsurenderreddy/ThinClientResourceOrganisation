using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.GetCreateRequest;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.New
{
    public class NewNationalityPresenter
                        : Presenter
    {
        public ActionResult Editor()
        {
            var response = _get_new_nationality_request.create();
            var view_model = _create_nationality_editor_builder.build( response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public NewNationalityPresenter( IGetCreateNationalityRequest get_new_nationality_request,
                                        EditorBuilder< CreateNationalityRequest > create_nationality_editor_builder
                                      )
        {
            _get_new_nationality_request = Guard.IsNotNull( get_new_nationality_request, "get_new_nationality_request" );
            _create_nationality_editor_builder = Guard.IsNotNull( create_nationality_editor_builder,
                "create_nationality_editor_builder" );
        }

        private readonly IGetCreateNationalityRequest _get_new_nationality_request;
        private readonly EditorBuilder<CreateNationalityRequest> _create_nationality_editor_builder;
    }
}