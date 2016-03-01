using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Fields.TemplateName
{
    public class TemplateName_can_be_specified_for_a_break_template
    {
        [TestClass]
        public class On_create
                        : FieldIsMappedCorrectlySpecification<NewBreakTemplateRequest,
                                                                NewBreakTemplateResponse,
                                                                NewBreakTemplateFixture,
                                                                BreakTemplate
                                                             >
        {
            protected override bool validate(NewBreakTemplateRequest request, BreakTemplate entity)
            {
                return request.template_name == entity.template_name;
            }
        }

        [TestClass]
        public class On_update
                        : FieldIsMappedCorrectlySpecification<UpdateBreakTemplateRequest,
                                                            UpdateBreakTemplateResponse,
                                                            UpdateBreakTeamplateFixture,
                                                            BreakTemplate
                                                            >
        {
            protected override bool validate(UpdateBreakTemplateRequest request, BreakTemplate entity)
            {
                return request.template_name == entity.template_name;
            }
        }
    }
}