using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New
{
    public class NewBreakTemplateFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<NewBreakTemplateRequest,
                                                                        NewBreakTemplateResponse,
                                                                        INewBreakTemplate,
                                                                        BreakTemplate
                                                                     >
    {
        public override BreakTemplate entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                return _repository
                            .Entities
                            .Single()
                            ;
            }
        }

        public NewBreakTemplateFixture(INewBreakTemplate the_new_break_template_command,
                                            IRequestHelper<NewBreakTemplateRequest> the_new_break_template_request_builder,
                                            IEntityRepository<BreakTemplate> the_repository
                                           )
            : base(the_new_break_template_command,
                    the_new_break_template_request_builder
                  )
        {
            _repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IEntityRepository<BreakTemplate> _repository;
    }
}