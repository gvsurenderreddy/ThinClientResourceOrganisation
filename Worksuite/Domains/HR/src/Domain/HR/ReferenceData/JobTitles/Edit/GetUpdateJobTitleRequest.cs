using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit
{
    public class GetUpdateJobTitleRequest
                    : GetUpdateReferenceDataRequest<JobTitle, UpdateJobTitleRequest, GetUpdateJobTitleRequestResponse>,
                        IGetUpdateJobTitleRequest
    {
        public GetUpdateJobTitleRequest(IEntityRepository<JobTitle> the_repository)
            : base(the_repository) { }
    }
}