using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Remove
{
    [TestClass]
    public class RemoveQualification_will
                    : CommandCommitedChangesSpecification<  RemoveQualificationRequest,
                                                            RemoveQualificationResponse,
                                                            RemoveQualificationFixture
                                                         > {}
}