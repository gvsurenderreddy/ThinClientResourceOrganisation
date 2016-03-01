using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Presentation.New {

    public class NewGenderPresenter
                    : Presenter {

        public ActionResult Editor () {
            var new_request = new_gender_request.create( );
            var view_model = editor_builder.build( new_request.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public NewGenderPresenter 
                    ( IGetCreateGenderRequest get_new_gender_request 
                    , EditorBuilder<CreateGenderRequest> the_editor_builder )  {
            
            new_gender_request = Guard.IsNotNull( get_new_gender_request, "get_new_gender_request" );
            editor_builder = Guard.IsNotNull( the_editor_builder, "the_editor_builder" );
        }

        private readonly IGetCreateGenderRequest new_gender_request;
        private readonly EditorBuilder<CreateGenderRequest> editor_builder;
    }
}