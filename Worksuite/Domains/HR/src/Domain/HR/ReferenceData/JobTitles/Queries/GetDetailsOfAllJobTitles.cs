using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries
{
    public class GetDetailsOfAllJobTitles
                    : GetDetailsOfAllReferenceData<JobTitle, JobTitleDetails>
                    , IGetDetailsOfAllJobTitles
    {
        public GetDetailsOfAllJobTitles
                     (IQueryRepository<JobTitle> the_repository)
            : base
                   (the_repository) { }
    }
}