using FluentAssertions;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Remove
{
    [TestClass]
    public class Remove_shift_template_should
                         : PlannedSupplySpecification
    {
        [ TestMethod]
        public void shift_should_be_remove()
        {
            var break_template = break_template_helper
                                    .add()
                                    .template_name("6:00 - 16:00 breakk template")
                                    .entity
                                    ;   

            shift_template_builder=new ShiftTemplateBuilder(new PlannedSupply.ShiftTemplates.ShiftTemplate()
            {
                shift_title = "6:00-16:00",
                start_time_in_seconds_from_midnight = 43800,
                duration_in_seconds = 5100,
                colour = "23,34,56",
                break_template = break_template
            });

            entity = shift_template_builder.entity;
            repository.add(entity);

            var request = get_request.execute(new ShiftTemplateIdentity()
            {
                shift_template_id = entity.id
            }).result;

            var response = command.execute(new ShiftTemplateIdentity()
            {
               shift_template_id = request.shift_template_id
            });
            response.has_errors.Should().BeFalse();

            
        }

        protected override void test_setup()
        {
            base.test_setup();
            shift_template_builder = DependencyResolver.resolve<ShiftTemplateBuilder>();
            get_request = DependencyResolver.resolve<IGetRemoveShiftTemplateRequest>();
            command = DependencyResolver.resolve<IRemoveShiftTemplate>();
            repository = DependencyResolver.resolve<IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate>>();
            break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
        }

        private ShiftTemplateBuilder shift_template_builder;
        private IGetRemoveShiftTemplateRequest get_request;
        private IRemoveShiftTemplate command;
        private IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> repository;
        private PlannedSupply.ShiftTemplates.ShiftTemplate entity;
        private BreakTemplateHelper break_template_helper;
    }
}