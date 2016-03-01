using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.GetUpdateRequest;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit
{
    public class GetUpdateMaritalStatusRequest
                        :   GetUpdateReferenceDataRequest< MaritalStatus, UpdateMaritalStatusRequest, GetUpdateMaritalStatusRequestResponse >,
                            IGetUpdateMaritalStatusRequest
    {
        public GetUpdateMaritalStatusRequest (IEntityRepository< MaritalStatus > the_repository )
                        :   base( the_repository ) {}
    }
}
