using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Queries.GetDetailsOfASpecificNationality
{
    public class GetDetailsOfASpecificNationalityFixture
                        : GetDetailsOfASpecificReferenceDataFixture< Nationality, NationalityDetails, IGetDetailsOfASpecificNationality, NationalityBuilder, GetDetailsOfASpecificNationalityHelper>
    {
        public GetDetailsOfASpecificNationalityFixture( GetDetailsOfASpecificNationalityHelper the_request_builder,
                                                        IGetDetailsOfASpecificNationality the_query
                                                      )
                        : base( the_request_builder, the_query ) {}
    }
}
