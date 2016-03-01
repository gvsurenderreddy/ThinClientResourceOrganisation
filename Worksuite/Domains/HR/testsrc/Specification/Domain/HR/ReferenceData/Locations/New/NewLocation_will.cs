using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.New
{
    [TestClass]
    public class NewLocation_will
                    : CommandCommitedChangesSpecification<CreateLocationRequest,
                                                          CreateLocationResponse,
                                                          NewLocationFixture
                                                         > { }
}