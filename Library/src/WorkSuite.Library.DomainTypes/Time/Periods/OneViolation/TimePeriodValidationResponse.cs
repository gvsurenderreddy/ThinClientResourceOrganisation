using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods.OneViolation
{
    public class ViolationCheckResponse 
    {

        public sealed class Valid
                               : ViolationCheckResponse
        {
        }

        public sealed class Errors
                                : ViolationCheckResponse
        {
            public IEnumerable<ResponseMessage> errors { get; private set; }

            public Errors
                    (IEnumerable<ResponseMessage> errors)
            {
                this.errors = errors;
            }
        }

    }

    public static class ViolationCheckResponseExtensions
    {
        public static void Match
                            (this ViolationCheckResponse response
                            , Action<ViolationCheckResponse.Valid> is_valid
                            , Action<IEnumerable<ResponseMessage>> is_not_valid)
        {
            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valis");

            if (response is ViolationCheckResponse.Valid)
            {
                is_valid((response as ViolationCheckResponse.Valid));
                return;
            }

            if (response is ViolationCheckResponse.Errors)
            {
                is_not_valid((response as ViolationCheckResponse.Errors).errors);
                return;
            }

            throw new Exception("Unmatched case");
        }
    }
}