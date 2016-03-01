using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New
{
    [TestClass]
    public class NewMaritalStatus_will
                        :   CommandCommitedChangesSpecification<CreateMaritalStatusRequest, CreateMaritalStatusResponse, NewMaritalStatusFixture> {}
}
