using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Queries.GetDetailsOfAllMaritalStatuses
{
    public class GetDetailsOfAllMaritalStatusesFixture
                    : GetDetailsOfAllReferenceDataFixture<MaritalStatus, MaritalStatusDetails, IGetDetailsOfAllMaritalStatuses, MaritalStatusBuilder, FakeMaritalStatusRepository, MaritalStatusHelper>
    {
        public GetDetailsOfAllMaritalStatusesFixture(MaritalStatusHelper the_helper,
                                                IGetDetailsOfAllMaritalStatuses the_query
                                           )
            : base(the_helper,
                    the_query
                  )
        {
        }
    }
}
