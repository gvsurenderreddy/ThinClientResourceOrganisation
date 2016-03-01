using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.EditEditor
{
    public class BreakTemplateDetailsEditorPresenter
                        : Presenter
    {
        public ActionResult Editor(BreakTemplateIdentity the_break_template_identity)
        {
            UpdateBreakTemplateRequest update_break_template_request = _get_update_break_template_request
                                                                                        .execute(the_break_template_identity)
                                                                                        .result
                                                                                        ;

            var view_model = _update_break_template_request_editor_builder
                                    .build(update_break_template_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public BreakTemplateDetailsEditorPresenter(IGetUpdateBreakTemplateRequest the_get_update_break_template_request,
                                                        EditorBuilder<UpdateBreakTemplateRequest> the_update_break_template_request_editor_builder
                                                       )
        {
            _get_update_break_template_request = Guard.IsNotNull(the_get_update_break_template_request,
                                                                       "the_get_update_break_template_request"
                                                                      );
            _update_break_template_request_editor_builder = Guard.IsNotNull(the_update_break_template_request_editor_builder,
                                                                                  "the_update_break_template_request_editor_builder"
                                                                                 );
        }

        private readonly IGetUpdateBreakTemplateRequest _get_update_break_template_request;

        private readonly EditorBuilder<UpdateBreakTemplateRequest>
            _update_break_template_request_editor_builder;
    }
}