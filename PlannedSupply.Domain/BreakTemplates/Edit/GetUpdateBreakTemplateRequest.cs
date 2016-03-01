using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit
{
    public class GetUpdateBreakTemplateRequest
                        : IGetUpdateBreakTemplateRequest
    {
        public Response<UpdateBreakTemplateRequest> execute(BreakTemplateIdentity the_request)
        {
            BreakTemplate shift_break_template = shift_break_template_repository
                                                            .Entities
                                                            .Single(sbt => sbt.id == the_request.template_id)
                                                            ;

            return new Response<UpdateBreakTemplateRequest>
                            {
                                result = new UpdateBreakTemplateRequest
                                                {
                                                    template_id = shift_break_template.id,
                                                    template_name = shift_break_template.template_name,
                                                    is_hidden = shift_break_template.is_hidden
                                                }
                            };
        }

        public GetUpdateBreakTemplateRequest(IEntityRepository<BreakTemplate> the_shift_break_template_repository)
        {
            shift_break_template_repository = Guard.IsNotNull(the_shift_break_template_repository,
                                                               "the_shift_break_template_repository"
                                                              );
        }

        private readonly IEntityRepository<BreakTemplate> shift_break_template_repository;
    }
}