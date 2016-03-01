using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Remove {

    public class RemoveTitleFixture
                    : RemoveRefereceDataFixture<RemoveTitleRequest,RemoveTitleResponse,IRemoveTitle> {

        public RemoveTitleFixture 
                       ( IRemoveTitle the_command
                       , IRequestHelper<RemoveTitleRequest> the_request_builder ) 
                : base ( the_command
                        , the_request_builder ) {}

    }

}