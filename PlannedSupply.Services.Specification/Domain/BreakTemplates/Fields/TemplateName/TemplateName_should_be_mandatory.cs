using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Fields.TemplateName
{
    public class TemplateName_should_be_mandatory
    {
        [TestClass]
        public class On_create
                        : MandatoryTextFieldSpecification<NewBreakTemplateRequest,
                                                            NewBreakTemplateResponse,
                                                            NewBreakTemplateFixture
                                                         >
        {
            public On_create()
                : base((request, value) => request.template_name = value) { }
        }

        [TestClass]
        public class On_update
                        : MandatoryTextFieldSpecification<UpdateBreakTemplateRequest,
                                                            UpdateBreakTemplateResponse,
                                                            UpdateBreakTeamplateFixture
                                                         >
        {
            public On_update()
                : base((request, value) => request.template_name = value) { }
        }
    }
}