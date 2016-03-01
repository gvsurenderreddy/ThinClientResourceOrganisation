using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Queries.GetAll
{
    public class GetDetailsOfAllBreaks
                    : IGetDetailsOfAllBreaks
    {
        public Response<IEnumerable<BreakDetails>> execute(BreakTemplateIdentity the_break_template_identity)
        {
            BreakTemplate break_template = break_template_query_repository
                                                            .Entities
                                                            .Single(sbt => sbt.id == the_break_template_identity.template_id)
                                                            ;

            var all_breaks = break_template
                                        .all_breaks
                                        .OrderBy(sb => sb.offset_from_start_time_in_seconds)
                                        .AsEnumerable()
                                        .Select(sb => new BreakDetails
                                                            {
                                                                template_id = break_template.id,
                                                                break_id = sb.id,
                                                                off_set = sb.offset_from_start_time_in_seconds.to_duration_request(),
                                                                duration = sb.duration_in_seconds.to_duration_request(),
                                                                is_paid = sb.is_paid
                                                            }
                                        );

            var response = new GetDetailsOfAllBreaksResponse
                                    {
                                        messages = null,
                                        has_errors = false,
                                        result = all_breaks
                                    };

            return response;
        }

        public GetDetailsOfAllBreaks(IQueryRepository<BreakTemplate> the_break_template_query_repository)
        {
            break_template_query_repository = Guard.IsNotNull(the_break_template_query_repository, "the_break_template_query_repository");
        }
        private readonly IQueryRepository<BreakTemplate> break_template_query_repository;
    }
}