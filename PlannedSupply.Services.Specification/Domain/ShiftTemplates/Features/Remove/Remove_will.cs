using System.Linq;
using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Remove
{
    [TestClass]
    public class Remove_will
                    : CommandCommitedChangesSpecification<ShiftTemplateIdentity,RemoveShiftTemplateResponse,RemoveFixture>
    {
        [TestMethod]
        public void remove_the_shift_template()
        {
            fixture.execute_command();
            fake_repository.Entities.Select(x => x.id == fixture.request.shift_template_id).Should().BeEmpty();
        }

        [TestMethod]
        public void show_no_errors_if_entity_is_null()
        {
            fake_repository.Entities
                .ToList()
                .Clear();
            fixture.execute_command();
            fixture.response.has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void return_successful_message_if_the_shift_template_id_does_not_exist()
        {
            var break_template = break_template_helper
                                    .add()
                                    .template_name("6:00 - 16:00 breakk template")
                                    .entity
                                    ;    

            shift_template_builder = new ShiftTemplateBuilder(new PlannedSupply.ShiftTemplates.ShiftTemplate()
            {
                shift_title = "6:00-16:00",
                start_time_in_seconds_from_midnight = 43800,
                duration_in_seconds = 5100,
                colour = "23,34,56",
                break_template = break_template
            });

            entity = shift_template_builder.entity;
            repository.add(entity);
           
            var response = command.execute(new ShiftTemplateIdentity()
            {
                shift_template_id = -1
            });

            response.messages.Should().Contain(m => m.message == ConfirmationMessages.confirmation_04_0025);
        }
        protected override void test_setup()
        {
            base.test_setup();
            fake_repository = DependencyResolver.resolve<FakeShiftTemplateRepository>();
            shift_template_builder = DependencyResolver.resolve<ShiftTemplateBuilder>();
            repository = DependencyResolver.resolve<IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate>>();
            command = DependencyResolver.resolve<IRemoveShiftTemplate>();
            break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
        }

        private FakeShiftTemplateRepository fake_repository;
        private PlannedSupply.ShiftTemplates.ShiftTemplate entity;
        private IRemoveShiftTemplate command;
        private IEntityRepository<PlannedSupply.ShiftTemplates.ShiftTemplate> repository;
        private ShiftTemplateBuilder shift_template_builder;
        private BreakTemplateHelper break_template_helper;
    }
}