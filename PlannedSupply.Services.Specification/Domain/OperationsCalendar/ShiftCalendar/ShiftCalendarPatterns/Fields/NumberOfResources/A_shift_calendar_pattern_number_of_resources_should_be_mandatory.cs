using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Fields.NumberOfResources
{
    public class A_shift_calendar_pattern_number_of_resources_should_be_mandatory
    {
        [TestClass]
        public class On_create
                        : MandatoryTextFieldSpecification<NewShiftCalendarPatternRequest,
                                                            NewShiftCalendarPatternResponse,
                                                            NewShiftCalendarPatternFixture
                                                         >
        {
            public On_create()
                : base((request, value) => request.number_of_resources = value) { }
        }

        [TestClass]
        public class On_update
                        : MandatoryTextFieldSpecification<UpdateShiftCalendarPatternRequest,
                            UpdateShiftCalendarPatternResponse,
                            UpdateShiftCalendarPatternFixture
                            >
        {
            public On_update()
                : base((request, value) => request.number_of_resources = value) { }
        }
    }
}