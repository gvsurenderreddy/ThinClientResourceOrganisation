using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.Mapper;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllAssociatedShiftTemplates
{
    public class GetAllAssociatedShiftTemplatesForBreakTemplate
                        : IGetAllAssociatedShiftTemplatesForBreakTemplate
    {
        public Response<IEnumerable<ShiftTemplateDetails>> execute(BreakTemplateIdentity the_shift_break_template)
        {
            var all_associated_shift_templates = _shift_template_repository
                                                    .Entities
                                                    .OrderBy( st => st.shift_title )
                                                    .Where( st => ( st.break_template != null ) && ( st.break_template.id == the_shift_break_template.template_id ) )
                                                    .ToList()
                                                    .Select(_shift_temmplate_mapper.Map.Compile())
                                                    ;

            return new Response<IEnumerable<ShiftTemplateDetails>>
            {
                result = all_associated_shift_templates,
                messages = null,
                has_errors = false
            };
        }

        public GetAllAssociatedShiftTemplatesForBreakTemplate(IQueryRepository<ShiftTemplates.ShiftTemplate> the_shift_template_repository,
                                                                   IShiftTemplatesDetailsMapper the_shift_temmplate_mapper
                                                                  )
        {
            _shift_template_repository = Guard.IsNotNull(the_shift_template_repository, "the_shift_template_repository");
            _shift_temmplate_mapper = Guard.IsNotNull(the_shift_temmplate_mapper, "the_shift_temmplate_mapper");
        }

        private readonly IQueryRepository<ShiftTemplates.ShiftTemplate> _shift_template_repository;
        private readonly IShiftTemplatesDetailsMapper _shift_temmplate_mapper;
    }
}