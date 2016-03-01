using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Queries.GetDetailsOfAllNationalities
{
    [TestClass]
    public class Correctly_maps_is_hidden_for_a_nationality
                        : Correctly_maps_is_hidden< Nationality,
                                                    NationalityBuilder,
                                                    NationalityDetails,
                                                    GetDetailsOfAllNationalitiesFixture
                                                  > {}
}