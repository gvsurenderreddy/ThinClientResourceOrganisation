using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit
{
    public class GetUpdateBreakRequest
                        : IGetUpdateBreakRequest
    {
        public Response<UpdateBreakRequest> execute(BreakIdentity the_break_identity)
        {
            BreakTemplate break_template = break_template_repository
                                                            .Entities
                                                            .Single(sbt => sbt.id == the_break_identity.template_id)
                                                            ;

            var all_breaks_order_by_off_set_in_seconds = break_template
                                                                    .all_breaks
                                                                    .OrderBy(sbt => sbt.offset_from_start_time_in_seconds)
                                                                    .ToList()
                                                                    ;

            Breaks.Break one_break = break_template
                                        .all_breaks
                                        .Single(sb => sb.id == the_break_identity.break_id);

            var current_priority = all_breaks_order_by_off_set_in_seconds.IndexOf(one_break) + 1;

            return new Response<UpdateBreakRequest>
            {
                result = new UpdateBreakRequest
                {
                    template_id = break_template.id,
                    break_id = one_break.id,
                    off_set = one_break.offset_from_start_time_in_seconds.to_duration_request(),
                    duration = one_break.duration_in_seconds.to_duration_request(),
                    is_paid = one_break.is_paid,
                    current_priority = current_priority.ToString()
                }
            };
        }

        public GetUpdateBreakRequest(IEntityRepository<BreakTemplate> the_break_template_repository)
        {
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
        }

        private readonly IEntityRepository<BreakTemplate> break_template_repository;
    }
}