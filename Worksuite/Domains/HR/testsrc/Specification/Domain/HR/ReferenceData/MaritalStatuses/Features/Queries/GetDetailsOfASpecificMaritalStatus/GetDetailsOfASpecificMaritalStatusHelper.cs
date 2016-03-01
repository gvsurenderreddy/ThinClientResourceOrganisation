using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Queries.GetDetailsOfASpecificMaritalStatus
{
    public class GetDetailsOfASpecificMaritalStatusHelper
                        :   GetDetailsOfASpecificReferenceDataRequestHelper< MaritalStatus, MaritalStatusBuilder >
    {
        public GetDetailsOfASpecificMaritalStatusHelper(   IEntityRepository< MaritalStatus > theMaritalStatusRepository,
                                                    MaritalStatusBuilder theMaritalStatusBuilder
                                                )
                           :    base(   theMaritalStatusRepository,
                                        theMaritalStatusBuilder
                                    ) {}
    }
}
