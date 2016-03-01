using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Description
{
    [TestClass]
    public class The_description_for_a_qualification_is_sanatised_when_updating
                    : The_description_is_sanatised_when_updating<   Qualification,
                                                                    UpdateQualificationRequest,
                                                                    UpdateQualificationResponse,
                                                                    IUpdateQualification,
                                                                    UpdateQualificationFixture
                                                                > { }
}