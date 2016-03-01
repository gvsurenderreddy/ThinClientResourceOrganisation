using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New
{
    /// <summary>
    ///     Creates a new 'CreateQualificationRequest' object
    /// </summary>
    public class GetCreateQualificationRequest
                            : GetCreateReferenceDataRequest< CreateQualificationRequest, GetCreateQualificationRequestResponse >,
                                IGetCreateQualificationRequest { }
}