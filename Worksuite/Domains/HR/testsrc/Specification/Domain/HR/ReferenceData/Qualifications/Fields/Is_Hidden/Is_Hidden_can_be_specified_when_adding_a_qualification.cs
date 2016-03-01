using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_qualification
            : Is_Hidden_can_be_specified_when_adding_a_new_entry<   Qualification,
                                                                    CreateQualificationRequest,
                                                                    CreateQualificationResponse,
                                                                    ICreateQualification,
                                                                    NewQualificationFixture
                                                                > { }
}