using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.GetUpdateRequest;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit
{
    public class GetUpdateNationalityRequest
                        :   GetUpdateReferenceDataRequest< Nationality, UpdateNationalityRequest, GetUpdateNationalityRequestResponse >,
                            IGetUpdateNationalityRequest
    {
        public GetUpdateNationalityRequest( IEntityRepository< Nationality > the_repository )
                        :   base( the_repository ) {}
    }
}