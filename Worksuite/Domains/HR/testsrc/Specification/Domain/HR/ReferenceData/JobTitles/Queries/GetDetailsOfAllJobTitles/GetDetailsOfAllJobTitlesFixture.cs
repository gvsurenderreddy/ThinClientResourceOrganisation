using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Queries.GetDetailsOfAllJobTitles
{
    public class GetDetailsOfAllJobTitlesFixture
                    : GetDetailsOfAllReferenceDataFixture<JobTitle, JobTitleDetails, IGetDetailsOfAllJobTitles, JobTitleBuilder, FakeJobTitleRepository, JobTitleHelper>
    {
        public GetDetailsOfAllJobTitlesFixture(JobTitleHelper the_helper,
                                               IGetDetailsOfAllJobTitles the_query
                                              )
            : base(the_helper,
                   the_query
                  ) { }
    }
}