using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Queries.GetDetailsOfASpecificTraining
{
    [TestClass]
    public class Returns_the_correct_qualification
                    : Returns_the_correct_entity<   Qualification,
                                                    QualificationBuilder,
                                                    QualificationDetails,
                                                    GetDetailsOfASpecificQualificationFixture
                                                > { }
}