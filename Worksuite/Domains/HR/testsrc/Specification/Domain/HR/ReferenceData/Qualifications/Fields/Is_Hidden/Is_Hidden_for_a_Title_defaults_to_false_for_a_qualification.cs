using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_for_a_Title_defaults_to_false_for_a_qualification
                    : Is_Hidden_defaults_to_false<  CreateQualificationRequest,
                                                    GetCreateQualificationRequestResponse,
                                                    IGetCreateQualificationRequest
                                                 > { }
}