using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Remove
{
    [TestClass]
    public class Remove_Job_Title_will
                    : CommandCommitedChangesSpecification<RemoveJobTitleRequest,
                                                          RemoveJobTitleResponse,
                                                          RemoveJobTitleFixture
                                                         > { }
}