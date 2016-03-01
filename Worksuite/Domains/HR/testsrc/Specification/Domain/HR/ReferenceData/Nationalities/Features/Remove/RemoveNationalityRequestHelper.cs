using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Remove
{
    public class RemoveNationalityRequestHelper
                        : RemoveReferenceDataRequestBuilder< Nationality, RemoveNationalityRequest >
    {
        public RemoveNationalityRequestHelper( IEntityRepository< Nationality > the_repository )
                        : base( the_repository ) {}
    }
}