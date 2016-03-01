using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit
{
    [TestClass]
    public class UpdateJobTitle_will
                    : CommandCommitedChangesSpecification<UpdateJobTitleRequest,
                                                          UpdateJobTitleResponse,
                                                          UpdateJobTitleFixture
                                                         > { }


    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<JobTitle,
                                                                        UpdateJobTitleRequest,
                                                                        UpdateJobTitleResponse,
                                                                        IUpdateJobTitle,
                                                                        JobTitleUpdatedEvent,
                                                                        UpdateJobTitleEventFixture>
    {

    }
}