using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllEligibleForShiftTemplate
{
    public class GetDetailsOfBreakTemplatesEligibleForShiftTemplate
                            : IGetDetailsOfBreakTemplatesEligibleForShiftTemplate
    {
        public Response<IEnumerable<BreakTemplateDetails>> execute(ShiftTemplateIdentity the_shift_template)
        {
            return set_request(the_shift_template)
                       .include_assign_to_shift_template_in_result_set()
                       .inlcude_not_specified_in_result_set()
                       .include_not_hidden_in_result_set()
                       .response()
                       ;
        }


        private GetDetailsOfBreakTemplatesEligibleForShiftTemplate set_request(ShiftTemplateIdentity the_shift_template)
        {
            Guard.IsNotNull(the_shift_template, "the_shift_template");

            result_set = new List<BreakTemplateDetails>();
            final_result_set = new List<BreakTemplateDetails>();

            if (the_shift_template.shift_template_id == Null.Id) return this;

            shift_template = _shift_template_repository
                                .Entities
                                .Single(st => st.id == the_shift_template.shift_template_id)
                                ;

            return this;
        }

        private GetDetailsOfBreakTemplatesEligibleForShiftTemplate include_assign_to_shift_template_in_result_set()
        {
            if (shift_template == null) return this;

            associated_break_template = shift_template.break_template;

            if (associated_break_template == null) return this;

            var template_detail = new BreakTemplateDetails
            {
                template_id = associated_break_template.id,
                template_name = associated_break_template.template_name,
                is_hidden = associated_break_template.is_hidden
            };

            result_set.Add(template_detail);

            return this;
        }

        private GetDetailsOfBreakTemplatesEligibleForShiftTemplate inlcude_not_specified_in_result_set()
        {
            Guard.IsNotNull(result_set, "result_set");

            result_set.Add(not_specified());

            return this;
        }

        private GetDetailsOfBreakTemplatesEligibleForShiftTemplate include_not_hidden_in_result_set()
        {
            IEnumerable<BreakTemplateDetails> not_hidden_break_templates = new List<BreakTemplateDetails>();

            if (associated_break_template != null)
            {
                not_hidden_break_templates = _break_template_repository
                                                    .Entities
                                                    .Where(bt => !bt.is_hidden)
                                                    .Where(bt => bt.id != associated_break_template.id)
                                                    .OrderBy(bt => bt.template_name)
                                                    .Select(map)
                                                    .ToList()
                                                    ;                
            }
            else
            {
                not_hidden_break_templates = _break_template_repository
                                                    .Entities
                                                    .Where(bt => !bt.is_hidden)
                                                    .OrderBy(bt => bt.template_name)
                                                    .Select(map)
                                                    .ToList()
                                                    ;                
            }


            final_result_set = result_set.Concat(not_hidden_break_templates);

            return this;
        }

        private Response<IEnumerable<BreakTemplateDetails>> response()
        {
            return new Response<IEnumerable<BreakTemplateDetails>>
            {
                result = get_result_set_to_present_to_client()
            };  
        }

        private BreakTemplateDetails not_specified()
        {
            return new BreakTemplateDetails
            {
                template_id = NotSpecified.Id,
                template_name = NotSpecified.Description,
            };
        }

        private readonly Expression<Func<BreakTemplate, BreakTemplateDetails>> map = template =>
            // to do: change this use a mapper that is passed in
                                                     new BreakTemplateDetails
                                                     {
                                                         template_id = template.id,
                                                         template_name = template.template_name,
                                                         is_hidden = template.is_hidden,
                                                     };

        private IEnumerable<BreakTemplateDetails> get_result_set_to_present_to_client()
        {

            // if there are no entries then return an empty result set
            return only_contains_the_not_specified_element(final_result_set) ? new BreakTemplateDetails[] { } : final_result_set;
        }

        private bool only_contains_the_not_specified_element
                        (IEnumerable<BreakTemplateDetails> elements_to_check)
        {

            if (elements_to_check != null)
            {
                return final_result_set.Count() == 1 && final_result_set.Any(bt => bt.template_id == NotSpecified.Id);
            }
            return false;
        }

        public GetDetailsOfBreakTemplatesEligibleForShiftTemplate(IQueryRepository<ShiftTemplates.ShiftTemplate> the_shift_template_repository,
                                                        IQueryRepository<BreakTemplate> the_break_template_repository
                                                       )
        {
            _shift_template_repository = Guard.IsNotNull(the_shift_template_repository, "the_shift_template_repository");
            _break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
        }

        // result set that is returned in the response
        private List<BreakTemplateDetails> result_set;
        private IEnumerable<BreakTemplateDetails> final_result_set;

        // the employee to get eligible entities for        
        private ShiftTemplates.ShiftTemplate shift_template;

        // the entities that have been assigned to the employee
        private BreakTemplate associated_break_template;

        private readonly IQueryRepository<ShiftTemplates.ShiftTemplate> _shift_template_repository;
        private readonly IQueryRepository<BreakTemplate> _break_template_repository;
    }
}