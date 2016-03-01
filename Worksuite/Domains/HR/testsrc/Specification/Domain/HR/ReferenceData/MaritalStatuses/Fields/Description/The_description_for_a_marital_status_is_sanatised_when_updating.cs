using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Fields.Description
{
    [TestClass]
    public class The_description_for_a_marital_status_is_sanatised_when_updating
                        :   The_description_is_sanatised_when_updating< MaritalStatus, UpdateMaritalStatusRequest, UpdateMaritalStatusResponse, IUpdateMaritalStatus, UpdateMaritalStatusFixture > {}
}
