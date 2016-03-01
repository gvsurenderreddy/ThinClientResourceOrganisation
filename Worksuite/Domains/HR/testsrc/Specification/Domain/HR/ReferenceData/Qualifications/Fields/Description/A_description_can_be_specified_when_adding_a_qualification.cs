using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Description
{
    [TestClass]
    public class A_description_can_be_specified_when_adding_a_qualification
        : A_description_can_be_specified_when_adding_a_new_entry<   Qualification,
                                                                    CreateQualificationRequest,
                                                                    CreateQualificationResponse,
                                                                    ICreateQualification,
                                                                    NewQualificationFixture
                                                                > { }
}