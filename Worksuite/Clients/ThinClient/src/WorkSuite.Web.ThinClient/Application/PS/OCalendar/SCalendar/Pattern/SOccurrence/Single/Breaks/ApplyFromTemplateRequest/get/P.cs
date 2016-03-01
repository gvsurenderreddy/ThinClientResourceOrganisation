using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAll;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.TemplateEditor
{
    public class ApplyShiftBreaksFromBreakTemplateEditorPresenter : Presenter
    {
        public ActionResult Editor(ShiftOccurrenceIdentity shift_occurrence_identity)
        {
            var update_request = get_update_request.execute(shift_occurrence_identity).result;

            var break_templates = get_entries_eligible_for_dropdown();


            var view_model = editor_builder
                                    .set_lookup_values(m => m.break_template_id, break_templates)
                                    .build(update_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public ApplyShiftBreaksFromBreakTemplateEditorPresenter(IGetApplyShiftBreaksFromBreakTemplateRequest the_get_update_request
                                                                , IGetAllBreakTemplatesDetails the_get_all_break_templates
                                                                , EditorBuilder<ApplyShiftBreaksFromBreakTemplateRequest> the_editor_builder)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_update_request = Guard.IsNotNull(the_get_update_request, "the_get_update_request");
            get_all_break_templates = Guard.IsNotNull(the_get_all_break_templates, "the_get_all_break_templates");
        }

        private readonly IGetApplyShiftBreaksFromBreakTemplateRequest get_update_request;
        private readonly IGetAllBreakTemplatesDetails get_all_break_templates;
        private readonly EditorBuilder<ApplyShiftBreaksFromBreakTemplateRequest> editor_builder;


        private IEnumerable<LookupValue> get_entries_eligible_for_dropdown()
        {
            var entries = get_all_break_templates.execute()
                                                .result
                                                .Select(bt => new LookupValue
                                                {
                                                    id = bt.template_id.ToString(CultureInfo.InvariantCulture),
                                                    description = bt.template_name
                                                });


            if (entries.Any())
            {
                entries = blank().Union(entries);
            }

            return entries;
        }

        private static IEnumerable<LookupValue> blank()
        {
            yield return new LookupValue
            {
                id = "-2",
                description = "Choose",
            };
        }

    }
}