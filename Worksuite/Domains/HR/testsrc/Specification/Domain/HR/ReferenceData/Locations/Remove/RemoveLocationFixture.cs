using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Remove
{
    public class RemoveLocationFixture
                    : RemoveRefereceDataFixture<RemoveLocationRequest,
                                                RemoveLocationResponse,
                                                IRemoveLocation
                                               >
    {
        public RemoveLocationFixture(IRemoveLocation the_command,
                                     IRequestHelper<RemoveLocationRequest> the_request_builder
                                    )
            : base(the_command,
                   the_request_builder
                  ) { }
    }
}