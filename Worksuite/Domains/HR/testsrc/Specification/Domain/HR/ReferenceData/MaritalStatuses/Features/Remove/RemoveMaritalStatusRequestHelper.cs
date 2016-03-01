using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Remove
{
    public class RemoveMaritalStatusRequestHelper
                    :   RemoveReferenceDataRequestBuilder< MaritalStatus, RemoveMaritalStatusRequest >
    {
        public RemoveMaritalStatusRequestHelper( IEntityRepository< MaritalStatus > theMaritalStatusRepository )
                    :   base( theMaritalStatusRepository ) {}
    }
}
