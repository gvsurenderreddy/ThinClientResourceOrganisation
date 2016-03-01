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
    public class Description_for_a_Job_Title_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class Verify_on_create
                            : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<JobTitle,
                                                                                                              CreateJobTitleRequest,
                                                                                                              CreateJobTitleResponse,
                                                                                                              ICreateJobTitle,
                                                                                                              NewJobTitleFixture
                                                                                                             > { }

        [TestClass]
        public class Verify_on_update
                            : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<JobTitle,
                                                                                                              UpdateJobTitleRequest,
                                                                                                              UpdateJobTitleResponse,
                                                                                                              IUpdateJobTitle,
                                                                                                              UpdateJobTitleFixture
                                                                                                             > { }
    }
}