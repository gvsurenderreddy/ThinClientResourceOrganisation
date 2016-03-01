using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllEligibleForShiftTemplate;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.New.Page
{
    public class NewShiftTemplatePresenter
                  : Presenter
    {
        public ActionResult Page()
        {
            var request = get_new_shift_template_request.execute();

            var all_eligible_break_templates = get_break_templates_eligible_for_shift_template
                                                .execute(new ShiftTemplateIdentity { shift_template_id = Null.Id })
                                                .result
                                                .Select(bt => new LookupValue
                                                {
                                                    id = bt.template_id.ToString(CultureInfo.InvariantCulture),
                                                    description = bt.template_name,
                                                });


            var view_model = editor_builder_request
                                .set_lookup_values(m => m.break_template_id, all_eligible_break_templates)
                                .build(request);

            return View(@"~\Views\SetupOptions\ShiftTemplates\New\Page.cshtml", view_model);
        }

        public NewShiftTemplatePresenter
                           ( IGetNewShiftTemplatesRequest the_query,
                             IGetDetailsOfBreakTemplatesEligibleForShiftTemplate the_get_break_templates_eligible_for_shift_template,
                             EditorBuilder<NewShiftTemplatesRequest> the_editor_builder_request)
        {
            get_new_shift_template_request = Guard.IsNotNull(the_query, "the_query");
            editor_builder_request = Guard.IsNotNull(the_editor_builder_request, "the_editor_builder_request");
            get_break_templates_eligible_for_shift_template = Guard.IsNotNull(the_get_break_templates_eligible_for_shift_template,
                                                                               "the_get_break_templates_eligible_for_shift_template"
                                                                              );
        }

        private readonly IGetNewShiftTemplatesRequest get_new_shift_template_request;
        private IGetDetailsOfBreakTemplatesEligibleForShiftTemplate get_break_templates_eligible_for_shift_template;
        private readonly EditorBuilder<NewShiftTemplatesRequest> editor_builder_request;
    }
}