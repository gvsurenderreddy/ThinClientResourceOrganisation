using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.ShiftDetails.ShiftTemplateSummary;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Edit
{
    public class GetShiftTemplateUpdateRequest
                    : IGetShiftTemplateUpdateRequest
    {
        public Response<UpdateShiftTemplateRequest> execute(ShiftTemplateIdentity request)
        {
            ShiftTemplates.ShiftTemplate shift_template = query_repository
                .Entities
                .Single(x => x.id == request.shift_template_id);

            return new Response<UpdateShiftTemplateRequest>()
            {
                result = new UpdateShiftTemplateRequest()
                {
                    shift_template_id = request.shift_template_id,
                    shift_title = shift_template.shift_title,
                    start_time = shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                    duration = shift_template.duration_in_seconds.to_duration_request(),
                    colour = shift_template.colour.to_rgb_colour_request_from_persistence_format(),
                    break_template_id = shift_template.break_template != null ? shift_template.break_template.id : Null.Id
                }
            };
        }

        public GetShiftTemplateUpdateRequest(IQueryRepository<ShiftTemplates.ShiftTemplate> the_query_repository)
        {
            query_repository = Guard.IsNotNull(the_query_repository, "the_query_repository");
        }

        private readonly IQueryRepository<ShiftTemplates.ShiftTemplate> query_repository;
    }
}