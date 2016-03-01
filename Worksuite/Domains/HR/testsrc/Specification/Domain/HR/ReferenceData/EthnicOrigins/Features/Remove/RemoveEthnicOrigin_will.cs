using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Remove
{
    [TestClass]
    public class RemoveEthnicOrigin_will
                        : CommandCommitedChangesSpecification<  RemoveEthnicOriginRequest,
                                                                RemoveEthnicOriginResponse,
                                                                RemoveEthnicOriginFixture
                                                             > {}
}