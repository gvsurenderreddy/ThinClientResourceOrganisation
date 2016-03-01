using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Queries.GetDetailsOfAllNationalities
{
    public class GetDetailsOfAllNationalitiesFixture
                    : GetDetailsOfAllReferenceDataFixture<  Nationality,
                                                            NationalityDetails,
                                                            IGetDetailsOfAllNationalities,
                                                            NationalityBuilder,
                                                            FakeNationalityRepository,
                                                            NationalityHelper
                                                          >
    {
        public GetDetailsOfAllNationalitiesFixture( NationalityHelper the_helper,
                                                    IGetDetailsOfAllNationalities the_query
                                                  )
                            : base( the_helper, the_query ) {}
    }
}