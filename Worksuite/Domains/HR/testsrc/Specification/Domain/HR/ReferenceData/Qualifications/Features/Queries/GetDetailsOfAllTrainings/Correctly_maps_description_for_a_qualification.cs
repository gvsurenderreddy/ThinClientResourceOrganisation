using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Queries.GetDetailsOfAllTrainings
{
    [TestClass]
    public class Correctly_maps_description_for_a_qualification
                    : Correctly_maps_description<   Qualification,
                                                    QualificationBuilder,
                                                    QualificationDetails,
                                                    GetDetailsOfAllQualificationsFixture
                                                > { }
}