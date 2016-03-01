using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Queries.GetById
{
    public class GetBreakTemplateByIdFixture
                        : PlannedSupplySpecification
    {
        public BreakTemplateBuilder add_break_template()
        {
            BreakTemplateBuilder break_template_builder = new BreakTemplateBuilder(new BreakTemplate());

            _break_template_repository
                .add(break_template_builder.entity)
                ;

            return break_template_builder;
        }

        public GetBreakTemplateByIdFixture()
        {
            _break_template_repository = DependencyResolver.resolve<IEntityRepository<BreakTemplate>>();
        }

        private IEntityRepository<BreakTemplate> _break_template_repository;
    }
}