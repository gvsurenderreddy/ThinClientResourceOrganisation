using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Queries.GetDetailsOfASpecificNationality
{
    public class GetDetailsOfASpecificNationalityHelper
                        : GetDetailsOfASpecificReferenceDataRequestHelper< Nationality, NationalityBuilder > 
    {
        public GetDetailsOfASpecificNationalityHelper( IEntityRepository< Nationality > the_repository,
                                                        NationalityBuilder the_builder
                                                      )
                        : base( the_repository, the_builder ) {}
    }
}
