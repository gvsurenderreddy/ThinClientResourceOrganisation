using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit
{
    public class UpdateNationalityRequestHelper
                        : UpdateReferenceDataRequestBuilder< Nationality, UpdateNationalityRequest >
    {
        public UpdateNationalityRequestHelper( IEntityRepository< Nationality > the_repository )
                        : base( the_repository ) {}
    }
}