using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.RemoveEditor
{
    public class RemoveBreakTemplatePresenter
                        : Presenter
    {
        public ActionResult Editor(BreakTemplateIdentity the_break_template_identity)
        {
            RemoveBreakTemplateRequest request = _get_remove_break_template_request
                                                            .execute(the_break_template_identity)
                                                            .result
                                                            ;

            var view_model = _remove_break_template_request_editor_builder
                                    .build(request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public RemoveBreakTemplatePresenter(EditorBuilder<RemoveBreakTemplateRequest> the_remove_break_template_request_editor_builder,
                                                    IGetRemoveBreakTemplateRequest the_get_remove_break_template_request
                                                )
        {
            _remove_break_template_request_editor_builder = Guard.IsNotNull(the_remove_break_template_request_editor_builder,
                                                                                  "the_remove_break_template_request_editor_builder"
                                                                                 );
            _get_remove_break_template_request = Guard.IsNotNull(the_get_remove_break_template_request,
                                                                       "the_get_remove_break_template_request"
                                                                      );
        }

        private readonly EditorBuilder<RemoveBreakTemplateRequest>
            _remove_break_template_request_editor_builder;

        private readonly IGetRemoveBreakTemplateRequest _get_remove_break_template_request;
    }
}