using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck
{
    public class ViolationCheckResult
    {
        public sealed class Valid
                            : ViolationCheckResult{}

        public sealed class BlockClashError
                            : ViolationCheckResult {}
    }

    public static class violationCheckResultExtension
    {
        public static bool has_been_decided(this ViolationCheckResult result)
        {
            return result != null;
        }

        public static T Match <T> ( this ViolationCheckResult validation_result
                                  , Func<ViolationCheckResult.Valid, T> is_valid
                                  , Func<ViolationCheckResult.BlockClashError, T> is_not_valid)
        {
            if (validation_result is ViolationCheckResult.Valid)
            {
                return is_valid((validation_result as ViolationCheckResult.Valid));
            }
            if (validation_result is ViolationCheckResult.BlockClashError)
            {
                return is_not_valid((validation_result as ViolationCheckResult.BlockClashError));
            }

            throw new Exception( "Unmached case" );
        }

        public static void Match ( this ViolationCheckResult validation_result
                                 , Action<ViolationCheckResult.Valid> is_valid
                                 , Action<ViolationCheckResult.BlockClashError> is_not_valid)
        {
            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valid");

            validation_result
                .Match(
                    is_valid:
                        valid_result => { is_valid(valid_result); return new Unit(); },

                    is_not_valid:
                        in_valid_result => { is_not_valid(in_valid_result); return new Unit(); }

                );
        }
    }

    public static class VolationcheckErrorExtension
    {
        public static void Match( this ViolationCheckResult.BlockClashError error
                                , Action<ViolationCheckResult.BlockClashError> time_period_is_not_valid)
        {
            Guard.IsNotNull(time_period_is_not_valid, "time_period_is_not_valid");
            if (true)
            {
                time_period_is_not_valid(error);
            }
        }
    }
}
