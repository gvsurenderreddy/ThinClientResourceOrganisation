using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates.ShiftBreaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit
{
    public class UpdateBreakFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateBreakRequest,
                                                                          UpdateBreakResponse,
                                                                          IUpdateBreak,
                                                                          Breaks.Break
                                                                         >
    {
        public UpdateBreakRequest update_request
        {
            get
            {
                if (break_identity == null)
                    break_identity = break_identity_helper.get_identity();

                return new UpdateBreakRequest
                {
                    template_id = break_identity.template_id,
                    break_id = break_identity.break_id,
                    off_set = new DurationRequest
                                    {
                                        hours = "1",
                                        minutes = "30"
                                    },
                    duration = new DurationRequest
                                        {
                                            hours = "0",
                                            minutes = "15"
                                        },
                    is_paid = false
                };
            }
        }

        public Maybe<UpdateBreakResponse> update_response
        {
            get;
            private set;
        }

        public virtual void execute_command(BreakIdentity the_break_identity)
        {
            break_identity = the_break_identity;

            update_response = update_break_command.execute(update_request).to_maybe();
        }

        public override Breaks.Break entity
        {
            get
            {
                var break_template = break_template_repository
                                                .Entities
                                                .Single(sbt => sbt.id == request.template_id)
                                                ;

                return break_template
                            .all_breaks
                            .Single(sb => sb.id == request.break_id)
                            ;
            }
        }

        public UpdateBreakFixture(IUpdateBreak the_update_break,
                                       IRequestHelper<UpdateBreakRequest> the_update_break_request_builder,
                                       IEntityRepository<BreakTemplate> the_break_template_repository
                                      )
            : base(the_update_break,
                   the_update_break_request_builder
                  )
        {
            break_template_repository = Guard.IsNotNull(the_break_template_repository,
                                                               "the_break_template_repository"
                                                              );

            update_response = new Nothing<UpdateBreakResponse>();
            break_identity_helper = DependencyResolver.resolve<BreakIdentityHelper>();
            update_break_command = DependencyResolver.resolve<IUpdateBreak>();
        }

        private readonly IEntityRepository<BreakTemplate> break_template_repository;
        private readonly IUpdateBreak update_break_command;
        private readonly BreakIdentityHelper break_identity_helper;
        private BreakIdentity break_identity;
    }
}