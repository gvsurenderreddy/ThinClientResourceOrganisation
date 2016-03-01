using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.EditShiftBreak
{
    public class ClashingBreakValidation
    {
        [TestClass]
        public class OnUpdate : CheckClashingBreakBetweenPeersSpecification < EditShiftBreakRequest
                                                                            , EditShiftBreakResponse
                                                                            , EditShiftBreakFixture >
        {
            public OnUpdate()
                : base((request, new_break_off_set_request, new_break_duration_request) =>
                {
                    request.off_set = new_break_off_set_request;
                    request.duration = new_break_duration_request;
                }) { }
        }

    }
}