
using System.Collections.Generic;
using Content.Services.PlannedSupply.Messages;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate
{
    public class FindOrCreateTimeAllocationValidationErrors
    {
        #region"TITLE"
        public const string TITLE_IS_NOT_SPECIFIED = "TITLE_IS_NOT_SPECIFIED";
        public const string TITLE_EXCEEDS_MAX_CHARACTERS = "TITLE_EXCEEDS_MAX_CHARACTERS";
        #endregion

        #region"COLOUR"
        public const string COLOUR_IS_NOT_VALID = "COLOUR_IS_NOT_VALID";
        #endregion

        #region"START_TIME"
        public const string START_TIME_EXCEEDS_24_HOURS = "START_TIME_EXCEEDS_24_HOURS";

        public const string START_TIME_HOURS_IS_NOT_SPECIFIED = "START_TIME_HOURS_IS_NOT_SPECIFIED";

        public const string START_TIME_MINUTES_IS_NOT_SPECIFIED = "START_TIME_MINUTES_IS_NOT_SPECIFIED";

        public const string START_TIME_HOURS_IS_NOT_A_NUMBER = "START_TIME_HOURS_IS_NOT_A_NUMBER";

        public const string START_TIME_MINUTES_IS_NOT_A_NUMBER = "START_TIME_MINUTES_IS_NOT_A_NUMBER";
        #endregion

        #region"DURATION"
        public const string DURATION_IS_NOT_WITHIN_24_HOURS = "DURATION_IS_NOT_WITHIN_24_HOURS";

        public const string DURATION_HOURS_IS_NOT_SPECIFIED = "DURATION_HOURS_IS_NOT_SPECIFIED";

        public const string DURATION_MINUTES_IS_NOT_SPECIFIED = "DURATION_MINUTES_IS_NOT_SPECIFIED";

        public const string DURATION_HOURS_IS_NOT_A_NUMBER = "DURATION_HOURS_IS_NOT_A_NUMBER";

        public const string DURATION_MINUTES_IS_NOT_A_NUMBER = "DURATION_MINUTES_IS_NOT_A_NUMBER";
        #endregion

        #region"BREAK OFFSET"
        public const string BREAK_OFFSET_HOURS_IS_NOT_SPECIFIED = "BREAK_OFFSET_HOURS_IS_NOT_SPECIFIED";

        public const string BREAK_OFFSET_MINUTES_IS_NOT_SPECIFIED = "BREAK_OFFSET_MINUTES_IS_NOT_SPECIFIED";

        public const string BREAK_OFFSET_HOURS_IS_NOT_A_NUMBER = "BREAK_OFFSET_HOURS_IS_NOT_A_NUMBER";

        public const string BREAK_OFFSET_MINUTES_IS_NOT_A_NUMBER = "BREAK_OFFSET_MINUTES_IS_NOT_A_NUMBER";
        #endregion

        #region"BREAK DURATION"
        public const string BREAK_DURATION_HOURS_IS_NOT_SPECIFIED = "BREAK_DURATION_HOURS_IS_NOT_SPECIFIED";

        public const string BREAK_DURATION_MINUTES_IS_NOT_SPECIFIED = "BREAK_DURATION_MINUTES_IS_NOT_SPECIFIED";

        public const string BREAK_DURATION_HOURS_IS_NOT_A_NUMBER = "BREAK_DURATION_HOURS_IS_NOT_A_NUMBER";

        public const string BREAK_DURATION_MINUTES_IS_NOT_A_NUMBER = "BREAK_DURATION_MINUTES_IS_NOT_A_NUMBER";
        #endregion

        #region"BREAK MODEL"
        public const string BREAK_MODEL_CLASHES_WITH_ANOTHER = "BREAK_MODEL_CLASHES_WITH_ANOTHER";

        public const string BREAK_MODEL_DURATION_IS_ZERO = "BREAK_MODEL_DURATION_IS_ZERO";
        #endregion

        #region"SHIFT AND BREAK MODEL"
        public const string SHIFT_CLASHES_WITH_A_BREAK = "SHIFT_CLASHES_WITH_A_BREAK";
        #endregion
    
    }

    public class ShiftErrorReportingPolicy : IIndex<string, IEnumerable<ResponseMessage>>
    {
        public Maybe<IEnumerable<ResponseMessage>> lookup(string key)
        {
            return criteria.ContainsKey(key)
                ? criteria[key].to_maybe()
                : default(IEnumerable<ResponseMessage>).to_maybe();
        }


        public ShiftErrorReportingPolicy()
        {
            criteria = new Dictionary<string, IEnumerable<ResponseMessage>>()
            {
                {
                    FindOrCreateTimeAllocationValidationErrors.TITLE_IS_NOT_SPECIFIED,
                    ValidationMessages.error_00_0072.ToResponseMessage("shift_title").ToEnumerable()
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.TITLE_EXCEEDS_MAX_CHARACTERS,
                    ValidationMessages.error_00_0051.ToResponseMessage("shift_title").ToEnumerable()
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.COLOUR_IS_NOT_VALID,
                    "Error".ToResponseMessage("colour").ToEnumerable()
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.START_TIME_EXCEEDS_24_HOURS,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0055.ToResponseMessage("start_time"),
                        "error".ToResponseMessage("start_time.hours"),
                        "error".ToResponseMessage("start_time.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.START_TIME_HOURS_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0053.ToResponseMessage("start_time"),
                        "error".ToResponseMessage("start_time.hours")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.START_TIME_MINUTES_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0053.ToResponseMessage("start_time"),
                        "error".ToResponseMessage("start_time.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.START_TIME_HOURS_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0054.ToResponseMessage("start_time"),
                        "error".ToResponseMessage("start_time.hours")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.START_TIME_MINUTES_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0054.ToResponseMessage("start_time"),
                        "error".ToResponseMessage("start_time.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.DURATION_IS_NOT_WITHIN_24_HOURS,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0058.ToResponseMessage("duration"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.DURATION_HOURS_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0056.ToResponseMessage("duration"),
                        "error".ToResponseMessage("duration.hours")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.DURATION_MINUTES_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0056.ToResponseMessage("duration"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.DURATION_HOURS_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0057.ToResponseMessage("duration"),
                        "error".ToResponseMessage("duration.hours")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.DURATION_MINUTES_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        ValidationMessages.error_00_0057.ToResponseMessage("duration"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.SHIFT_CLASHES_WITH_A_BREAK,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }


                },
                {
                   ClashingShiftValidationErrors.SHIFT_CLASHE_WITH_PEER,
                   new List<ResponseMessage>()
                   {
                        ValidationMessages.error_00_0009.ToResponseMessage("start_time"),
                        "error".ToResponseMessage("start_time.hours"),
                        "error".ToResponseMessage("start_time.minutes"),
                        ValidationMessages.error_00_0009.ToResponseMessage("duration"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                   }
                },
                
            };
        }


        private readonly Dictionary<string, IEnumerable<ResponseMessage>> criteria;
    }


    public class ShiftBreakErrorReportingPolicy : IIndex<string, IEnumerable<ResponseMessage>>
    {
        public Maybe<IEnumerable<ResponseMessage>> lookup(string key)
        {
            return criteria.ContainsKey(key)
                ? criteria[key].to_maybe()
                : default(IEnumerable<ResponseMessage>).to_maybe();
        }


        public ShiftBreakErrorReportingPolicy()
        {
            criteria = new Dictionary<string, IEnumerable<ResponseMessage>>()
            {
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_HOURS_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_MINUTES_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_HOURS_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_MINUTES_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_HOURS_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_MINUTES_IS_NOT_SPECIFIED,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_HOURS_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_MINUTES_IS_NOT_A_NUMBER,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_MODEL_DURATION_IS_ZERO,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.BREAK_MODEL_CLASHES_WITH_ANOTHER,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes")
                    }
                },
                {
                    FindOrCreateTimeAllocationValidationErrors.SHIFT_CLASHES_WITH_A_BREAK,
                    new List<ResponseMessage>()
                    {
                        "error".ToResponseMessage("off_set.hours"),
                        "error".ToResponseMessage("off_set.minutes"),
                        "error".ToResponseMessage("duration.hours"),
                        "error".ToResponseMessage("duration.minutes"),
                        "".ToResponseMessage("break_template_id")
                    }
                },
            };
        }


        private readonly Dictionary<string, IEnumerable<ResponseMessage>> criteria;
    }

}
