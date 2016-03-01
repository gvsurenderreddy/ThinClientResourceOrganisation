using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetById
{
    public class GetBreakTemplateDetailsById
                        : IGetBreakTemplateDetailsById
    {
        public Response<GetBreakTemplateByIdResponse> execute(BreakTemplateIdentity the_request)
        {
            BreakTemplate shift_break_template = _shift_break_template_query_repository
                                                            .Entities
                                                            .Single(sbt => sbt.id == the_request.template_id)
                                                            ;

            var all_shift_breaks_order_by_off_set_in_seconds = shift_break_template
                                                                    .all_breaks
                                                                    .OrderBy(sb => sb.offset_from_start_time_in_seconds)
                                                                    .ToList()
                                                                    ;

            var all_shift_break_details = all_shift_breaks_order_by_off_set_in_seconds
                                                .Select(sb => new BreakDetails
                                                                    {
                                                                        template_id = shift_break_template.id,
                                                                        break_id = sb.id,
                                                                        off_set = sb.offset_from_start_time_in_seconds.to_duration_request(),
                                                                        duration = sb.duration_in_seconds.to_duration_request(),
                                                                        is_paid = sb.is_paid,
                                                                        order = all_shift_breaks_order_by_off_set_in_seconds.IndexOf(sb) + 1
                                                                    }
                                                );

            return new Response<GetBreakTemplateByIdResponse>
                            {
                                result = new GetBreakTemplateByIdResponse
                                                {
                                                    template_id = shift_break_template.id,
                                                    template_name = shift_break_template.template_name,
                                                    is_hidden = shift_break_template.is_hidden,
                                                    all_breaks = all_shift_break_details
                                                }
                            };
        }

        public GetBreakTemplateDetailsById(IQueryRepository<BreakTemplate> the_shift_break_template_query_repository)
        {
            _shift_break_template_query_repository = Guard.IsNotNull(the_shift_break_template_query_repository,
                                                                     "the_shift_break_template_query_repository"
                                                                    );
        }

        private readonly IQueryRepository<BreakTemplate> _shift_break_template_query_repository;
    }
}