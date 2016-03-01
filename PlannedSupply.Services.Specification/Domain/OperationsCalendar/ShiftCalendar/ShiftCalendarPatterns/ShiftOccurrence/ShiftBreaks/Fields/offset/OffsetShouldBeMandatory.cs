using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.EditShiftBreak;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreak;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Fields.offset
{
    public class OffsetShouldBeMandatory
    {
        [TestClass]
        public class OnCreate : MandatoryDurationFieldSpecification < NewShiftBreakRequest,
                                                                      NewShiftBreakResponse,
                                                                      NewShiftBreakFixture>
        {
            public OnCreate()
                : base((request, offset) => request.off_set = new DurationRequest { hours = offset.hours, minutes = offset.minutes }) { }
        }

        [TestClass]
        public class OnUpdate : MandatoryDurationFieldSpecification < EditShiftBreakRequest,
                                                                      EditShiftBreakResponse,
                                                                      EditShiftBreakFixture>
        {
            public OnUpdate()
                : base((request, offset) => request.off_set = new DurationRequest { hours = offset.hours, minutes = offset.minutes }) { }
        }
 
    }
}