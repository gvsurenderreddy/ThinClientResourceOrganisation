using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Queries.GetDetailsOfASpecificTraining
{
    public class GetDetailsOfASpecificQualificationFixture
                    :   GetDetailsOfASpecificReferenceDataFixture<  Qualification,
                                                                    QualificationDetails,
                                                                    IGetDetailsOfASpecificQualification,
                                                                    QualificationBuilder,
                                                                    GetDetailsOfASpecificQualificationHelper
                                                               >
    {
        public GetDetailsOfASpecificQualificationFixture(GetDetailsOfASpecificQualificationHelper theTrainingRequestBuilder,
                                                            IGetDetailsOfASpecificQualification theSpecificTrainingDetailsQuery
                                                        )
                    :   base(   theTrainingRequestBuilder,
                               theSpecificTrainingDetailsQuery
                            ) {}
    }
}