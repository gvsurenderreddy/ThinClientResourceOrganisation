using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit
{
    [TestClass]
    public class Update_will
                    :CommandCommitedChangesSpecification< UpdateShiftTemplateRequest
                                                         ,UpdateShiftTemplateResponse
                                                         ,UpdateShiftTemplateFixture> { }
}
