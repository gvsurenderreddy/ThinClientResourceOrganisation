using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit
{
    public class UpdateBreakTeamplateFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateBreakTemplateRequest,
                                                                            UpdateBreakTemplateResponse,
                                                                            IUpdateBreakTemplate,
                                                                            BreakTemplate
                                                                         >
    {
        public override BreakTemplate entity
        {
            get
            {
                return _break_template_repository
                                .Entities
                                .Single(sbt => sbt.id == request.template_id && sbt.template_name == request.template_name)
                                ;
            }
        }

        public UpdateBreakTeamplateFixture(IUpdateBreakTemplate the_update_break_template,
                                                IRequestHelper<UpdateBreakTemplateRequest> the_update_break_template_request_builder,
                                                IEntityRepository<BreakTemplate> the_break_template_repository
                                               )
            : base(the_update_break_template,
                    the_update_break_template_request_builder
                  )
        {
            _break_template_repository = Guard.IsNotNull(the_break_template_repository,
                                                               "the_break_template_repository"
                                                              );
        }

        private readonly IEntityRepository<BreakTemplate> _break_template_repository;
    }
}