using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Queries.GetAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Queries.GetAll
{
    public class GetDetailsOfAllBreaksFixture
    {
        public BreakTemplateIdentity request
        {
            get
            {
                return new BreakTemplateIdentity
                {
                    template_id = break_template_identity.template_id
                };
            }
        }

        public Maybe<List<BreakDetails>> response
        {
            get;
            private set;
        }

        public virtual void execute_command()
        {
            response = get_details_of_all_breaks_command.execute(request).result.ToList().to_maybe();
        }

        public BreakBuilder add_break()
        {
            var break_builder = new BreakBuilder(new Breaks.Break());
            var breakk = break_builder.entity;

            break_template
                .all_breaks
                .Add(breakk)
                ;

            return break_builder;
        }

        public GetDetailsOfAllBreaksFixture()
        {
            var break_template_identity_helper = DependencyResolver.resolve<BreakTemplateIdentityHelper>();
            break_template_identity = break_template_identity_helper.get_identity();

            var break_template_repository = DependencyResolver.resolve<FakeBreakTemplateRepository>();
            break_template = break_template_repository
                                        .Entities
                                        .Single(sbt => sbt.id == break_template_identity.template_id)
                                        ;

            response = new Nothing<List<BreakDetails>>();
            get_details_of_all_breaks_command = DependencyResolver.resolve<IGetDetailsOfAllBreaks>();
        }

        private readonly IGetDetailsOfAllBreaks get_details_of_all_breaks_command;
        private readonly BreakTemplateIdentity break_template_identity;
        public BreakTemplate break_template;
    }
}