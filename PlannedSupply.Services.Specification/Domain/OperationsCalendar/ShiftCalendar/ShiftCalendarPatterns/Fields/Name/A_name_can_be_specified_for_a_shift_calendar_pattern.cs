using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Fields.Name
{
    public class A_name_can_be_specified_for_a_shift_calendar_pattern
    {
        [TestClass]
        public class On_create
                        : FieldIsMappedCorrectlySpecification<NewShiftCalendarPatternRequest,
                                                                NewShiftCalendarPatternResponse,
                                                                NewShiftCalendarPatternFixture,
                                                                ShiftCalendarPattern
                                                             >
        {
            protected override bool validate(NewShiftCalendarPatternRequest request,
                                                ShiftCalendarPattern entity
                                            )
            {
                return request.pattern_name == entity.name;
            }
        }

        [TestClass]
        public class On_update
                        : FieldIsMappedCorrectlySpecification<UpdateShiftCalendarPatternRequest,
                                                                UpdateShiftCalendarPatternResponse,
                                                                UpdateShiftCalendarPatternFixture,
                                                                ShiftCalendarPattern
                                                             >
        {
            protected override bool validate(UpdateShiftCalendarPatternRequest request, ShiftCalendarPattern entity)
            {
                return request.pattern_name == entity.name;
            }
        }
    }
}