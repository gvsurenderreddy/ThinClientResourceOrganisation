using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New
{
    [TestClass]
    public class NewEthnicOrigin_will
                        : CommandCommitedChangesSpecification<  CreateEthnicOriginRequest,
                                                                CreateEthnicOriginResponse,
                                                                NewEthnicOriginFixture
                                                             > {}
}
