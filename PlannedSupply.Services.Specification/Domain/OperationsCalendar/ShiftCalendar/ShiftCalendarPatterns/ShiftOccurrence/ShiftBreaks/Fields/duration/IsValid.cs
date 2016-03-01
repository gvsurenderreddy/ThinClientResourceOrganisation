using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.EditShiftBreak;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreak;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Fields.duration
{
    public class IsValid 
    {
        [TestClass]
        public class OnCreate : DurationSanitisationSpecification < NewShiftBreakRequest,
                                                                    NewShiftBreakResponse,
                                                                    NewShiftBreakFixture >
        {
            public OnCreate()
                : base((request, duration) => request.duration = new DurationRequest { hours = duration.hours, minutes = duration.minutes }) { }
        }

        [TestClass]
        public class OnUpdate : DurationSanitisationSpecification < EditShiftBreakRequest,
                                                                    EditShiftBreakResponse,
                                                                    EditShiftBreakFixture >
        {
            public OnUpdate()
                : base((request, duration) => request.duration = new DurationRequest { hours = duration.hours, minutes = duration.minutes }) { }
        }
    }

  
}