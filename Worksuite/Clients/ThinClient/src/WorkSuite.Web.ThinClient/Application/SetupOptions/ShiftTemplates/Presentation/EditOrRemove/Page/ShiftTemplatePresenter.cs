using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.Page
{
    public class EditShiftTemplatePresenter
                  : Presenter
    {
        public ActionResult Page(ShiftTemplateIdentity shift_template)
        {
            var view_model = view_model_builder.For(shift_template)
              .build();

            return View(@"~\Views\SetupOptions\ShiftTemplates\EditOrRemove\Page.cshtml", view_model);
        }

        public EditShiftTemplatePresenter
                        (EditOrRemoveShiftTemplateDetailsViewModelBuilder the_view_model_builder
                      )
        {
            view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
        }

         private readonly EditOrRemoveShiftTemplateDetailsViewModelBuilder view_model_builder;
    }
}