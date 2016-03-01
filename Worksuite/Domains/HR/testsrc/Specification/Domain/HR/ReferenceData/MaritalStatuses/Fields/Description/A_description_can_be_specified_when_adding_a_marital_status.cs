using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Fields.Description
{
    [TestClass]
    public class A_description_can_be_specified_when_adding_a_marital_status
            : A_description_can_be_specified_when_adding_a_new_entry<MaritalStatus, CreateMaritalStatusRequest, CreateMaritalStatusResponse, ICreateMaritalStatus, NewMaritalStatusFixture> {}
}
