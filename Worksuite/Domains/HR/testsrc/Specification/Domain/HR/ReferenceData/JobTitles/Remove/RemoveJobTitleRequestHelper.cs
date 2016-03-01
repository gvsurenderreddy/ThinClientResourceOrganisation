using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Remove
{
    public class RemoveJobTitleRequestHelper
                    : RemoveReferenceDataRequestBuilder<JobTitle,
                                                        RemoveJobTitleRequest
                                                       >
    {
        public RemoveJobTitleRequestHelper(IEntityRepository<JobTitle> the_repository)
            : base(the_repository) { }
    }
}