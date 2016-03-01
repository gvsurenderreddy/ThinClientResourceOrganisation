using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_marital_status
        :   Is_Hidden_can_be_specified_when_adding_a_new_entry<MaritalStatus, CreateMaritalStatusRequest, CreateMaritalStatusResponse, ICreateMaritalStatus, NewMaritalStatusFixture> {}
}
