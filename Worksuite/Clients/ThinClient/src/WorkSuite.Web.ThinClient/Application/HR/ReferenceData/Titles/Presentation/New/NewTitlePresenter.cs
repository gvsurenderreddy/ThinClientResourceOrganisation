using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Presentation.New
{
    public class NewTitlePresenter : Presenter
    {

        public ActionResult Editor ()
        {
            var new_request = new_title_request.create( );
            var view_model = editor_builder.build( new_request.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public NewTitlePresenter 
            ( IGetCreateTitleRequest get_new_title_request 
            , EditorBuilder<CreateTitleRequest> the_editor_builder )  {
            
            Guard.IsNotNull( get_new_title_request, "get_new_title_request" );
            Guard.IsNotNull( the_editor_builder, "the_editor_builder" );

            new_title_request = get_new_title_request;
            editor_builder = the_editor_builder;
        }

        private readonly IGetCreateTitleRequest new_title_request;
        private readonly EditorBuilder<CreateTitleRequest> editor_builder;
    }
}