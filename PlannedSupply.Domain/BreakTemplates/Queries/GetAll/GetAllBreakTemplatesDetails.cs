using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Mapper;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAll
{
    public class GetAllBreakTemplatesDetails
                        : IGetAllBreakTemplatesDetails
    {
        public GetAllBreakTemplatesResponse execute()
        {
            var entity = _shift_break_template_query_repository
                                .Entities
                                .OrderBy(sbt => sbt.template_name)
                                .ToList()
                                .Select(_shift_break_template_details_mapper.Map.Compile())
                                ;

            return new GetAllBreakTemplatesResponse
                            {
                                messages = null,
                                has_errors = false,
                                result = entity
                            };
        }

        public GetAllBreakTemplatesDetails(IQueryRepository<BreakTemplate> the_shift_break_template_query_repository,
                                                IBreakTemplateDetailsMapper the_shift_break_template_details_mapper
                                               )
        {
            _shift_break_template_query_repository = Guard.IsNotNull(the_shift_break_template_query_repository,
                                                                    "the_shift_break_template_query_repository"
                                                                    );

            _shift_break_template_details_mapper = Guard.IsNotNull(the_shift_break_template_details_mapper,
                                                                  "the_shift_break_template_details_mapper"
                                                                  );
        }

        private readonly IQueryRepository<BreakTemplate> _shift_break_template_query_repository;
        private readonly IBreakTemplateDetailsMapper _shift_break_template_details_mapper;
    }
}