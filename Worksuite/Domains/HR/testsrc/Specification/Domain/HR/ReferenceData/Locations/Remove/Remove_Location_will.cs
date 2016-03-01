using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Remove
{
    [TestClass]
    public class Remove_Location_will
                    : CommandCommitedChangesSpecification<RemoveLocationRequest,
                                                          RemoveLocationResponse,
                                                          RemoveLocationFixture
                                                         > { }
}