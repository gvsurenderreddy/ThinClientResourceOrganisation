using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Remove {

    public class RemoveGenderFixture
                    : RemoveRefereceDataFixture<RemoveGenderRequest,RemoveGenderResponse,IRemoveGender> {

        public RemoveGenderFixture
                       ( IRemoveGender the_command
                       , IRequestHelper<RemoveGenderRequest> the_request_builder ) 
                : base ( the_command
                       , the_request_builder ) {}

    }

}