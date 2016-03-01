using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.is_hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_job_title
                    : Is_Hidden_can_be_specified_when_adding_a_new_entry<JobTitle,
                                                                         CreateJobTitleRequest,
                                                                         CreateJobTitleResponse,
                                                                         ICreateJobTitle,
                                                                         NewJobTitleFixture
                                                                        > { }
}