using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Fields.Description
{
    [TestClass]
    public class A_description_for_a_marital_status_can_not_be_duplicated_is_validated_on_update
                    :   A_description_can_not_be_duplicated_is_validated_on_update< MaritalStatus, UpdateMaritalStatusRequest, UpdateMaritalStatusResponse, IUpdateMaritalStatus, UpdateMaritalStatusFixture > {}
}
