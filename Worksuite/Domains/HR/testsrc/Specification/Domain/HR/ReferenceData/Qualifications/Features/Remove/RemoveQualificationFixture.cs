using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Remove
{
    public class RemoveQualificationFixture
                    :   RemoveRefereceDataFixture< RemoveQualificationRequest, RemoveQualificationResponse, IRemoveQualification >
    {
        public RemoveQualificationFixture(  IRemoveQualification theRemoveTrainingCommand,
                                            IRequestHelper< RemoveQualificationRequest > theRemoveTrainingRequestBuilder
                                         )
                    :   base(   theRemoveTrainingCommand,
                                theRemoveTrainingRequestBuilder
                            ) {}
    }
}