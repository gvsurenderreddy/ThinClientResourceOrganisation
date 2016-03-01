using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove
{
    public class GetRemoveBreakTemplateRequest
                        : IGetRemoveBreakTemplateRequest
    {
        public Response<RemoveBreakTemplateRequest> execute(BreakTemplateIdentity the_request)
        {
            BreakTemplate shift_break_template = _shift_break_template_repository
                                                            .Entities
                                                            .Single(sbt => sbt.id == the_request.template_id)
                                                            ;

            var remove_request_response = new Response<RemoveBreakTemplateRequest>
                                                {
                                                    result = new RemoveBreakTemplateRequest
                                                                    {
                                                                        template_id = shift_break_template.id,
                                                                        template_name = shift_break_template.template_name,
                                                                        hidden_status = shift_break_template.is_hidden ? "Yes" : "No"
                                                                    }
                                                };

            return remove_request_response;
        }

        public GetRemoveBreakTemplateRequest(IEntityRepository<BreakTemplate> the_shift_break_template_repository)
        {
            _shift_break_template_repository = Guard.IsNotNull(the_shift_break_template_repository,
                                                               "the_shift_break_template_repository"
                                                              );
        }

        private readonly IEntityRepository<BreakTemplate> _shift_break_template_repository;
    }
}