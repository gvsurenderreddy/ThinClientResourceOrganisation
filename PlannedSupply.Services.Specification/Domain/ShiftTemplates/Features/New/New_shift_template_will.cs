using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New
{
    [TestClass]
    public class New_shift_template_will
                           : CommandCommitedChangesSpecification<NewShiftTemplatesRequest
                           , NewShiftTemplateResponse
                           , NewShiftTemplatesFixture>
    {
    }
}
  

