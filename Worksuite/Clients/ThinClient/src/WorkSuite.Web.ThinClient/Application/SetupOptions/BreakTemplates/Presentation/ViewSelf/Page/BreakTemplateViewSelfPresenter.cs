using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewSelf.Page
{
    public class BreakTemplateViewSelfPresenter
                        : Presenter
    {
        public ActionResult Page(BreakTemplateIdentity the_break_template)
        {
            var view_model = _view_model_builder
                                    .For(the_break_template)
                                    .build()
                                    ;

            var the_view_model = new BreakTemplateIdentityViewModel
            {
                identity = the_break_template,
                view_elements = view_model
            };

            return View(@"~\Views\SetupOptions\BreakTemplates\ViewSelf\Page.cshtml", the_view_model);
        }

        public BreakTemplateViewSelfPresenter(BreakTemplateViewModelBuilder the_view_model_builder)
        {
            _view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
        }

        private readonly BreakTemplateViewModelBuilder _view_model_builder;
    }
}