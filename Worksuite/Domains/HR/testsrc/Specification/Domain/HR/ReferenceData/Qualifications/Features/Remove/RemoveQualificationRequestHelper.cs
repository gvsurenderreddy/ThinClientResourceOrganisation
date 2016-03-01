using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Remove
{
    public class RemoveQualificationRequestHelper
                    : RemoveReferenceDataRequestBuilder< Qualification, RemoveQualificationRequest >
    {
        public RemoveQualificationRequestHelper( IEntityRepository< Qualification > theTrainingRepository )
                    :   base( theTrainingRepository ) {}
    }
}