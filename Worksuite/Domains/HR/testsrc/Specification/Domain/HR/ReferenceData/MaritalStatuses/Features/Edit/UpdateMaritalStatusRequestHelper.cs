using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit
{
    public class UpdateMaritalStatusRequestHelper
                    :   UpdateReferenceDataRequestBuilder< MaritalStatus, UpdateMaritalStatusRequest >
    {
        public UpdateMaritalStatusRequestHelper( IEntityRepository< MaritalStatus > theMaritalStatusRepository )
                    :   base( theMaritalStatusRepository ) {}
    }
}
