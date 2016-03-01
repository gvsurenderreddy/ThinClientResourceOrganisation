using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.GetCreateRequest;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Presentation.New
{
    public class NewRelationshipPresenter
                    : Presenter
    {

        public ActionResult Editor()
        {
            var new_request = new_relationship_request.create();
            var view_model = editor_builder.build(new_request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewRelationshipPresenter
                    (IGetCreateRelationshipRequest get_new_relationship_request
                    , EditorBuilder<CreateRelationshipRequest> the_editor_builder)
        {

            new_relationship_request = Guard.IsNotNull(get_new_relationship_request, "get_new_relationship_request");
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
        }

        private readonly IGetCreateRelationshipRequest new_relationship_request;
        private readonly EditorBuilder<CreateRelationshipRequest> editor_builder;
    }
}