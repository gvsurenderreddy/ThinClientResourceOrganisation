using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New {

    public class NewReferenceDataRequestHelper<Q>
                : IRequestHelper<Q>
        where Q : CreateReferenceDataRequest, new() {


        public virtual Q given_a_valid_request () {

            return new Q {
                description = "Mr",
                is_hidden = true,
            };
        }
    }
}