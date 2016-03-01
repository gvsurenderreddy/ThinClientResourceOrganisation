using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Queries.GetDetailsOfASpecificMaritalStatus
{
    public class GetDetailsOfASpecificMaritalStatusFixture
                    : GetDetailsOfASpecificReferenceDataFixture< MaritalStatus, MaritalStatusDetails, IGetDetailsOfASpecificMaritalStatus, MaritalStatusBuilder, GetDetailsOfASpecificMaritalStatusHelper >
    {
        public GetDetailsOfASpecificMaritalStatusFixture(   GetDetailsOfASpecificMaritalStatusHelper theMaritalStatusRequestBuilder,
                                                    IGetDetailsOfASpecificMaritalStatus theSpecificMaritalStatusDetailsQuery
                                                )
                        :   base(   theMaritalStatusRequestBuilder,
                                    theSpecificMaritalStatusDetailsQuery
                                ) {}
    }
}
