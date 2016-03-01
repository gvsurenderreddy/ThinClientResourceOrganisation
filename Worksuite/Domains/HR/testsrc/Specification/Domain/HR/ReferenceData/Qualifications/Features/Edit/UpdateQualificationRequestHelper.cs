using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit
{
    public class UpdateQualificationRequestHelper
                    : UpdateReferenceDataRequestBuilder<    Qualification,
                                                            UpdateQualificationRequest
                                                       >
    {
        public UpdateQualificationRequestHelper( IEntityRepository< Qualification > theTrainingRepository )
                    :   base( theTrainingRepository ) {}
    }
}
