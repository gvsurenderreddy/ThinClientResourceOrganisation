using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Remove
{
    [TestClass]
    public class Remove_will
                    :   CommandCommitedChangesSpecification< RemoveMaritalStatusRequest, RemoveMaritalStatusResponse, RemoveMaritalStatusFixture > {}
}
