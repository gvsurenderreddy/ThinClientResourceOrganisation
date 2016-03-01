using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit
{
    public class UpdateQualificationFixture
                    : UpdateRefereceDataFixture<    Qualification,
                                                    UpdateQualificationRequest,
                                                    UpdateQualificationResponse,
                                                    IUpdateQualification
                                               >
    {
        public UpdateQualificationFixture(   IUpdateQualification theUpdateTrainingCommand,
                                            IRequestHelper< UpdateQualificationRequest > theUpdateTrainingRequestBuilder,
                                            IEntityRepository< Qualification > theTrainingRepository
                                         )
                    :   base(   theUpdateTrainingCommand,
                                theUpdateTrainingRequestBuilder,
                                theTrainingRepository
                            ) {}
    }
}