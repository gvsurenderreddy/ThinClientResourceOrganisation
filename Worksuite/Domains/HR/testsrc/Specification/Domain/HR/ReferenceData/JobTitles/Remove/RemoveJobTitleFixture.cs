using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Remove
{
    public class RemoveJobTitleFixture
                    : RemoveRefereceDataFixture<RemoveJobTitleRequest,
                                                RemoveJobTitleResponse,
                                                IRemoveJobTitle
                                               >
    {
        public RemoveJobTitleFixture(IRemoveJobTitle the_command,
                                     IRequestHelper<RemoveJobTitleRequest> the_request_builder
                                    )
            : base(the_command,
                   the_request_builder
                  ) { }
    }
}