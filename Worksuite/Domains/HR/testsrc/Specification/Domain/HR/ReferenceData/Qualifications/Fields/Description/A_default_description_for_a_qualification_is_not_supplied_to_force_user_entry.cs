using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Description
{
    [TestClass]
    public class A_default_description_for_a_qualification_is_not_supplied_to_force_user_entry
                : A_default_description_is_not_supplied_to_force_user_entry<    CreateQualificationRequest,
                                                                                GetCreateQualificationRequestResponse,
                                                                                IGetCreateQualificationRequest
                                                                           > { }
}