using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.New.Page
{
    public class NewBreakTemplatePresenter
                    : Presenter
    {
        public ActionResult Page()
        {
            var request = _get_new_break_template_request
                                .execute()
                                ;

            var view_model = _new_break_template_request_editor_builder
                                .build(request)
                                ;

            return View(@"~\Views\SetupOptions\BreakTemplates\New\Page.cshtml", view_model);
        }

        public NewBreakTemplatePresenter(IGetNewBreakTemplateRequest the_get_new_break_template_request,
                                                EditorBuilder<NewBreakTemplateRequest> the_new_break_template_request_editor_builder
                                             )
        {
            _get_new_break_template_request = Guard.IsNotNull(the_get_new_break_template_request,
                                                                    "the_get_new_break_template_request"
                                                                   );

            
            _new_break_template_request_editor_builder = Guard.IsNotNull(the_new_break_template_request_editor_builder,
                                                                                "the_new_break_template_request_editor_builder"
                                                                              );
        }

        private readonly IGetNewBreakTemplateRequest _get_new_break_template_request;
        private readonly EditorBuilder<NewBreakTemplateRequest> _new_break_template_request_editor_builder;
    }
}