using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Queries.GetDetailsOfAllNationalities
{
    [TestClass]
    public class Return_all_nationalities
                        : Returns_all_entries<  Nationality,
                                                NationalityBuilder,
                                                NationalityDetails,
                                                GetDetailsOfAllNationalitiesFixture
                                             >
    {
    }
}