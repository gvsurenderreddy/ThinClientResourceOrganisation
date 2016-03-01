using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Presentation.Editor {

    public class TitleEditorPresenter
                    : Presenter {


        public ActionResult Editor
                                ( ReferenceDataIdentity for_title ) {

            var update_request = get_update_request.create( for_title );
            var view_model = editor_builder.build(update_request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }


        public TitleEditorPresenter
                    ( IGetUpdateTitleRequest get_update_request_query
                    , EditorBuilder<UpdateTitleRequest> the_editor_builder ) {

           get_update_request = Guard.IsNotNull( get_update_request_query, "get_update_request_query" );
           editor_builder = Guard.IsNotNull( the_editor_builder, "the_editor_builder" );
       }

        private readonly IGetUpdateTitleRequest get_update_request;
        private readonly EditorBuilder<UpdateTitleRequest> editor_builder;
    }
}