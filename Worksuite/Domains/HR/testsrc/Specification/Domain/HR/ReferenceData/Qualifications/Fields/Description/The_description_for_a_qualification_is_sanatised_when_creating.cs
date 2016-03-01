using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Description
{
    [TestClass]
    public class The_description_for_a_qualification_is_sanatised_when_creating
                        : A_description_is_mandatory_on_create< Qualification,
                                                                CreateQualificationRequest,
                                                                CreateQualificationResponse,
                                                                ICreateQualification,
                                                                NewQualificationFixture
                                                              > { }
}