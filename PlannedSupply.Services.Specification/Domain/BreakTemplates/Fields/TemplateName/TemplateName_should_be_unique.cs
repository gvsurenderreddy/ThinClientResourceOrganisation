using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Fields.TemplateName
{
    public class TemplateName_should_be_unique
    {
        [TestClass]
        public class On_create
                        : UniqueTextFieldSpecification<NewBreakTemplateRequest,
                                                        NewBreakTemplateResponse,
                                                        NewBreakTemplateFixture
                                                      >
        {
            protected override void create_entity_with_value(string the_value)
            {
                var break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
                var break_template = break_template_helper
                                                .add()
                                                .template_name(the_value)
                                                .entity
                                                ;
            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.template_name = the_value;
            }

            protected override string value
            {
                get { return "Another Shift Break Template"; }
            }
        }

        [TestClass]
        public class On_update
                        : UniqueTextFieldSpecification<UpdateBreakTemplateRequest,
                                                        UpdateBreakTemplateResponse,
                                                        UpdateBreakTeamplateFixture
                                                      >
        {
            [TestMethod]
            public void update_break_template_fixture_should_return_a_break_template_entity()
            {
                BreakTemplate break_template = fixture.entity;
                Assert.IsTrue(break_template.id != 0);
            }

            protected override void create_entity_with_value(string the_value)
            {
                BreakTemplateHelper break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
                BreakTemplate break_template = break_template_helper
                                                            .add()
                                                            .template_name(the_value)
                                                            .entity
                                                            ;
            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.template_name = the_value;
            }

            protected override string value
            {
                get { return "A shift breakk teamplate B"; }
            }
        }
    }
}