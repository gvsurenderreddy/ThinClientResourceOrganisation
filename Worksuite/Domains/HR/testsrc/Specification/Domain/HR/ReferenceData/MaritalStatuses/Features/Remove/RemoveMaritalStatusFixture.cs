using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Remove
{
    public class RemoveMaritalStatusFixture
                    : RemoveRefereceDataFixture< RemoveMaritalStatusRequest, RemoveMaritalStatusResponse, IRemoveMaritalStatus >
    {
        public RemoveMaritalStatusFixture(  IRemoveMaritalStatus theRemoveMaritalStatusCommand,
                                    IRequestHelper< RemoveMaritalStatusRequest > theRemoveMaritalStatusRequestBuilder
                                 )
                    :   base(   theRemoveMaritalStatusCommand,
                                theRemoveMaritalStatusRequestBuilder
                            ) {}
    }
}
