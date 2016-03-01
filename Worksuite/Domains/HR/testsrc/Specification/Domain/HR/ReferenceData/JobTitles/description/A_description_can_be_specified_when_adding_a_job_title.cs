using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.description
{
    [TestClass]
    public class A_description_can_be_specified_when_adding_a_job_title
                            : A_description_can_be_specified_when_adding_a_new_entry<JobTitle,
                                                                                     CreateJobTitleRequest,
                                                                                     CreateJobTitleResponse,
                                                                                     ICreateJobTitle,
                                                                                     NewJobTitleFixture
                                                                                    > { }
}