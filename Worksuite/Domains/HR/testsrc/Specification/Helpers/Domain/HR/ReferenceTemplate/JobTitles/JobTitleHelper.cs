using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles
{
    public class JobTitleHelper
                        : ReferenceDataHelper<JobTitle, JobTitleBuilder, FakeJobTitleRepository> { }
}