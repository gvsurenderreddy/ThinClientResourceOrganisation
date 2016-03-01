using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.GetAll;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.ShiftDetails.GetAll
{
    public class GetAllFixture
                  : PlannedSupplySpecification
    {
        
        protected ShiftTemplateBuilder add_shift_template()
        {
            var builder = new ShiftTemplateBuilder(new PlannedSupply.ShiftTemplates.ShiftTemplate());
            repository.add(builder.entity);
            return builder;
        }

        protected override void test_setup()
        {
            base.test_setup();

            repository = DependencyResolver.resolve<IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate>>();
            query = DependencyResolver.resolve<IGetAllShiftTemplates>();
        }

        protected IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> repository;
        protected IGetAllShiftTemplates query;
    }
}