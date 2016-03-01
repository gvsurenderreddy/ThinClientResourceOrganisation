using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New
{
    public class NewBreakFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<NewBreakRequest,
                                                                          NewBreakResponse,
                                                                          INewBreak,
                                                                          Breaks.Break
                                                                         >
    {
        public NewBreakRequest create_new_request
        {
            get
            {
                var _break_template_identity_helper = DependencyResolver.resolve<BreakTemplateIdentityHelper>();
                var break_template_identity = _break_template_identity_helper.get_identity();

                return new NewBreakRequest
                                {
                                    template_id = break_template_identity.template_id,
                                };
            }
        }

        public override Breaks.Break entity
        {
            get
            {
                BreakTemplate break_template = _break_template_repository
                                                                .Entities
                                                                .Single()
                                                                ;

                return break_template
                            .all_breaks
                            .SingleOrDefault()
                            ;
            }
        }

       

        public NewBreakFixture(INewBreak the_new_break,
                               IRequestHelper<NewBreakRequest> the_new_break_request_builder,
                               IEntityRepository<BreakTemplate> the_break_template_repository)
            
            : base(the_new_break,the_new_break_request_builder)
        {
            _break_template_repository = Guard.IsNotNull(the_break_template_repository,"the_break_template_repository");
        }

        private readonly IEntityRepository<BreakTemplate> _break_template_repository;

   
    }

   
}
