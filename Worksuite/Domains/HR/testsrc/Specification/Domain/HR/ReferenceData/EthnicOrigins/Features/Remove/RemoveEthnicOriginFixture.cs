using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Remove
{
    public class RemoveEthnicOriginFixture
                        : RemoveRefereceDataFixture<    RemoveEthnicOriginRequest,
                                                        RemoveEthnicOriginResponse,
                                                        IRemoveEthnicOrigin
                                                   > 
    {
        public RemoveEthnicOriginFixture(   IRemoveEthnicOrigin the_command,
                                            IRequestHelper< RemoveEthnicOriginRequest > the_request_builder
                                        )
            : base( the_command, the_request_builder ) {}
    }
}