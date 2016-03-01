using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New
{
    [TestClass]
    public class NewJobTitle_will
                    : CommandCommitedChangesSpecification<CreateJobTitleRequest,
                                                          CreateJobTitleResponse,
                                                          NewJobTitleFixture
                                                         > { }
}