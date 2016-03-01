using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.Edit
{
    public class BreakEditorPresenter
                        : Presenter
    {
        public ActionResult Editor(BreakIdentity the_break_identity)
        {
            var update_break_request = _get_update_break_request
                                                .execute(the_break_identity)
                                                .result
                                                ;

            var view_model = _update_break_request_editor_builder
                                    .build(update_break_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public BreakEditorPresenter(IGetUpdateBreakRequest the_get_update_break_request,
                                         EditorBuilder<UpdateBreakRequest> the_update_break_request_editor_builder
                                        )
        {
            _get_update_break_request = Guard.IsNotNull(the_get_update_break_request,
                                                              "the_get_update_break_request"
                                                             );

            _update_break_request_editor_builder = Guard.IsNotNull(the_update_break_request_editor_builder,
                                                                         "the_update_break_request_editor_builder"
                                                                        );
        }

        private readonly IGetUpdateBreakRequest _get_update_break_request;
        private readonly EditorBuilder<UpdateBreakRequest> _update_break_request_editor_builder;
    }
}