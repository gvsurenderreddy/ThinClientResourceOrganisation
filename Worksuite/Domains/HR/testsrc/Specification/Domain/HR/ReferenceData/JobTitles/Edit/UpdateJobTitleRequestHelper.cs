using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit
{
    public class UpdateJobTitleRequestHelper
                    : UpdateReferenceDataRequestBuilder<JobTitle,
                                                        UpdateJobTitleRequest
                                                       >
    {
        public UpdateJobTitleRequestHelper(IEntityRepository<JobTitle> the_repository)
            : base(the_repository) { }
    }
}