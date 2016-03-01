using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New
{
    [TestClass]
    public class NewQualification_will
                        : CommandCommitedChangesSpecification<  CreateQualificationRequest,
                                                                CreateQualificationResponse,
                                                                NewQualificationFixture
                                                             > { }
}