using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.GetAll;
using WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.WhiteSpaceTimeAllocationPaletteBuilderFactory;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.WhiteSpaceTimeAllocationPalette
{
    public class WhiteSpaceTimeAllocationPalettePresenter : Presenter
    {
        public ActionResult Page(TimeBlockIdentity request)
        {
            //Improve: This should ideally come from the service layer
            var create_request = new WhiteSpacePaletteDetails()
            {
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                start_date = request.start_date,
                shift_template_id = Null.Id,
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id
            };


            var view_model = builder
                                .set_time_allocation_template_lookup_values(entries_eligible_for_dropdown)
                                .build(create_request);

            return View(@"~\Views\Shared\Views\WhiteSpaceTimeAllocationPalette.cshtml", view_model);
        }

        public WhiteSpaceTimeAllocationPalettePresenter(DependencyResolverWhiteSpaceTimeAllocationPaletteBuilderFactory<WhiteSpacePaletteDetails> the_builder_factory
                                                        , IGetAllShiftTemplates the_get_shift_templates_query)
        {
            builder = Guard.IsNotNull(the_builder_factory, "the_builder_factory")
                .create_builder();

            get_shift_templates_query = Guard.IsNotNull(the_get_shift_templates_query, "the_get_shift_templates_query");
        }

        private readonly BuildDynamicWhiteSpaceTimeAllocationPaletteFromStaticDefinition<WhiteSpacePaletteDetails> builder;
        private readonly IGetAllShiftTemplates get_shift_templates_query;

        private IEnumerable<LookupValue> entries_eligible_for_dropdown
        {
            get
            {
                var shift_templates = get_shift_templates_query
                            .execute()
                            .result
                            .Select(t => new LookupValue
                            {
                                id = t.shift_template_id.ToString(CultureInfo.InvariantCulture),
                                description = t.shift_title,
                            });


                if (shift_templates.Any())
                {
                    shift_templates = blank().Union(shift_templates);
                }

                return shift_templates;
            }
        }

        //Improve: This method can be refactored
        //including the hard-coded string.
        private static IEnumerable<LookupValue> blank()
        {
            yield return new LookupValue
            {
                id = "-2",
                description = "Please select an option.",
            };
        }

    }

}