using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Queries.GetDetailsOfAllTrainings
{
    public  class GetDetailsOfAllQualificationsFixture
                    :   GetDetailsOfAllReferenceDataFixture<    Qualification,
                                                                QualificationDetails,
                                                                IGetDetailsOfAllQualifications,
                                                                QualificationBuilder,
                                                                FakeQualificationRepository,
                                                                QualificationHelper
                                                           >
    {
        public GetDetailsOfAllQualificationsFixture(    QualificationHelper theTrainingHelper,
                                                        IGetDetailsOfAllQualifications getAllTrainingDetailsQuery
                                                   )
                    :   base(   theTrainingHelper,
                                getAllTrainingDetailsQuery
                            ) {}
    }
}