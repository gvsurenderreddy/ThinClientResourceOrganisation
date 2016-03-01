using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove
{
    public class GetRemoveBreakRequest
                    : IGetRemoveBreakRequest
    {
        public Response<RemoveBreakRequest> execute(BreakIdentity the_shift_break_identity)
        {
            BreakTemplate shift_break_template = _shift_break_template_repository
                                                            .Entities
                                                            .Single(sbt => sbt.id == the_shift_break_identity.template_id)
                                                            ;

            var all_shift_breaks_order_by_off_set_in_seconds = shift_break_template
                                                                    .all_breaks
                                                                    .OrderBy(sbt => sbt.offset_from_start_time_in_seconds)
                                                                    .ToList()
                                                                    ;

            Breaks.Break shift_break = shift_break_template
                                                    .all_breaks
                                                    .Single(sb => sb.id == the_shift_break_identity.break_id)
                                                    ;

            int order = all_shift_breaks_order_by_off_set_in_seconds.IndexOf(shift_break) + 1;

            return new Response<RemoveBreakRequest>
                            {
                                result = new RemoveBreakRequest
                                                {
                                                    template_id = shift_break_template.id,
                                                    break_id = shift_break.id,
                                                    off_set = shift_break.offset_from_start_time_in_seconds.to_duration_request(),
                                                    duration = shift_break.duration_in_seconds.to_duration_request(),
                                                    is_paid = shift_break.is_paid,
                                                    current_priority = order.ToString()
                                                }
                            };
        }

        public GetRemoveBreakRequest(IQueryRepository<BreakTemplate> the_shift_break_template_repository)
        {
            _shift_break_template_repository = Guard.IsNotNull(the_shift_break_template_repository,
                                                               "the_shift_break_template_repository"
                                                              );
        }

        private readonly IQueryRepository<BreakTemplate> _shift_break_template_repository;
    }
}