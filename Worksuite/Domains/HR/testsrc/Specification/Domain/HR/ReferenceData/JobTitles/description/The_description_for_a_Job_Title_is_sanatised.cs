using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.description
{
    public class The_description_for_a_Job_Title_is_sanatised
    {
        [TestClass]
        public class When_creating
                        : The_description_is_sanatised_when_creating<JobTitle,
                                                                     CreateJobTitleRequest,
                                                                     CreateJobTitleResponse,
                                                                     ICreateJobTitle,
                                                                     NewJobTitleFixture
                                                                    > { }

        [TestClass]
        public class When_updating
                        : The_description_is_sanatised_when_updating<JobTitle,
                                                                     UpdateJobTitleRequest,
                                                                     UpdateJobTitleResponse,
                                                                     IUpdateJobTitle,
                                                                     UpdateJobTitleFixture
                                                                    > { }

        [TestClass]
        public class When_getting_an_update_request
                        : The_description_is_sanatised_when_getting_an_update_request<JobTitle,
                                                                                      UpdateJobTitleRequest,
                                                                                      GetUpdateJobTitleRequestResponse,
                                                                                      IGetUpdateJobTitleRequest
                                                                                     > { }
    }
}