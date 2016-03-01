using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefinitionList;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllAssociatedShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Mapper
{
    /// <summary>
    ///     Break template details mapper.
    /// </summary>
    public class BreakTemplateDetailsMapper
                        : IBreakTemplateDetailsMapper
    {
        public Expression<Func<BreakTemplate, BreakTemplateDetails>> Map
        {
            get
            {
                return shift_break_template => new BreakTemplateDetails
                                                        {
                                                            template_id = shift_break_template.id,
                                                            template_name = shift_break_template.template_name,
                                                            total_break_duration = calculate_total_break_duration(shift_break_template),
                                                            break_details = build_break_details(shift_break_template),
                                                            is_hidden = shift_break_template.is_hidden,
                                                            hidden_status = shift_break_template.is_hidden ? "Hidden" : string.Empty,
                                                            all_associated_shift_templates = build_associated_shift_templates_details(shift_break_template)
                                                        };
            }
        }

        private string calculate_total_break_duration(BreakTemplate the_shift_break_template)
        {
            var total_duration_in_DurationRequest = the_shift_break_template.all_breaks.AsEnumerable().Sum(sbd => sbd.duration_in_seconds).to_duration_request();

            return total_duration_in_DurationRequest.to_domain_format_string();
        }

        private IEnumerable<DefinitionListElement> build_break_details(BreakTemplate the_shift_break_template)
        {
            var all_shift_break_details = new List<DefinitionListElement>();

            int count = 0;

            var all_breaks = the_shift_break_template.all_breaks.OrderBy(sb => sb.offset_from_start_time_in_seconds).ToList();

            foreach (Breaks.Break shift_break in all_breaks)
            {
                count++;

                var is_paid = "Unpaid";
                if (shift_break.is_paid)
                    is_paid = "Paid";

                var title = "Break " + count;
                var definition = "Starts after " +
                                     shift_break.offset_from_start_time_in_seconds.to_duration_request().to_domain_format_string() + 
                                 ", Duration " +
                                 shift_break.duration_in_seconds.to_duration_request().to_domain_format_string() + 
                                 ", " + is_paid +
                                 ".";

                all_shift_break_details.Add(new DefinitionListElement(title, definition));
            }

            return all_shift_break_details.AsEnumerable();
        }

        private IEnumerable<DefinitionListElement> build_associated_shift_templates_details(BreakTemplate the_shift_break_template)
        {
            var all_associated_shift_templates_details = new List<DefinitionListElement>();

            var all_associated_shift_templates = get_all_associated_shift_templates
                                                    .execute(new BreakTemplateIdentity { template_id = the_shift_break_template.id })
                                                    .result
                                                    ;

            foreach (var shift_template in all_associated_shift_templates)
            {
                var title = shift_template.shift_title;
                var definition = "Start time " +
                                 shift_template.start_time.to_domain_string() +
                                 ", Duration " +
                                 shift_template.duration.to_domain_format_string() + 
                                 ".";

                all_associated_shift_templates_details.Add(new DefinitionListElement(title, definition));
            }

            return all_associated_shift_templates_details;
        }

        public BreakTemplateDetailsMapper(IGetAllAssociatedShiftTemplatesForBreakTemplate the_get_all_associated_shift_templates)
        {
            get_all_associated_shift_templates = Guard.IsNotNull( the_get_all_associated_shift_templates, "the_get_all_associated_shift_templates" );
        }

        private readonly IGetAllAssociatedShiftTemplatesForBreakTemplate get_all_associated_shift_templates;
    }
}