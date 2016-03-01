using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Queries.GetDetailsOfAllMaritalStatuses
{
    [TestClass]
    public class Return_all_MaritalStatuses
                    : Returns_all_entries<MaritalStatus, MaritalStatusBuilder, MaritalStatusDetails, GetDetailsOfAllMaritalStatusesFixture> { }
}
