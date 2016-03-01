using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Queries.GetDetailsOfASpecificTraining
{
    public class GetDetailsOfASpecificQualificationHelper
                    :   GetDetailsOfASpecificReferenceDataRequestHelper<   Qualification,
                                                                            QualificationBuilder
                                                                        >
    {
        public GetDetailsOfASpecificQualificationHelper(   IEntityRepository< Qualification > theQualificationRepository,
                                                            QualificationBuilder theQualificationBuilder
                                                        )
                    :   base(   theQualificationRepository,
                                theQualificationBuilder
                            ) {}
    }
}