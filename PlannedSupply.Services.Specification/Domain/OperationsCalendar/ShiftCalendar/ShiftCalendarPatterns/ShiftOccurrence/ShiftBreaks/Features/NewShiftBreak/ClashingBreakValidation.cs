using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreak
{
    public class ClashingBreakValidation
    {
        [TestClass]
        public class OnCreate : CheckClashingBreakBetweenPeersSpecification < NewShiftBreakRequest
                                                                            , NewShiftBreakResponse
                                                                            , NewShiftBreakFixture >
        {
            public OnCreate()
                : base((request, new_break_off_set_request, new_break_duration_request) =>
                {
                    request.off_set = new_break_off_set_request;
                    request.duration = new_break_duration_request;
                }) { }
        }

    }
}