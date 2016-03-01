using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.New
{
    public class NewBreakPresenter
                    : Presenter
    {
        public ActionResult Editor(BreakTemplateIdentity the_break_template_identity)
        {
            var new_break_request = _get_new_break_request
                                                .execute(new BreakIdentity { template_id = the_break_template_identity.template_id })
                                                ;

            var view_model = _new_break_request_editor_builder
                                    .build(new_break_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewBreakPresenter(IGetNewBreakRequest the_get_new_break_request,
                                      EditorBuilder<NewBreakRequest> the_new_break_request_editor_builder
                                     )
        {
            _get_new_break_request = Guard.IsNotNull(the_get_new_break_request,
                                                           "the_get_new_break_request"
                                                          );
            _new_break_request_editor_builder = Guard.IsNotNull(the_new_break_request_editor_builder,
                                                                      "the_new_break_request_editor_builder"
                                                                     );
        }

        private readonly IGetNewBreakRequest _get_new_break_request;
        private readonly EditorBuilder<NewBreakRequest> _new_break_request_editor_builder;
    }
}