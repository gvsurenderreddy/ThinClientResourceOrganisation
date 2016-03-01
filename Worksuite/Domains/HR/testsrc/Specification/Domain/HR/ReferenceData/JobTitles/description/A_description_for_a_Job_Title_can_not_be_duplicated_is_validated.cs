using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.description
{
    public class A_description_for_a_Job_Title_can_not_be_duplicated_is_validated
    {
        [TestClass]
        public class On_create
                        : A_description_can_not_be_duplicated_is_validated_on_create<JobTitle,
                                                                                     CreateJobTitleRequest,
                                                                                     CreateJobTitleResponse,
                                                                                     ICreateJobTitle,
                                                                                     NewJobTitleFixture
                                                                                    > { }

        [TestClass]
        public class On_update
                        : A_description_can_not_be_duplicated_is_validated_on_update<JobTitle,
                                                                                     UpdateJobTitleRequest,
                                                                                     UpdateJobTitleResponse,
                                                                                     IUpdateJobTitle,
                                                                                     UpdateJobTitleFixture
                                                                                    > { }
    }
}