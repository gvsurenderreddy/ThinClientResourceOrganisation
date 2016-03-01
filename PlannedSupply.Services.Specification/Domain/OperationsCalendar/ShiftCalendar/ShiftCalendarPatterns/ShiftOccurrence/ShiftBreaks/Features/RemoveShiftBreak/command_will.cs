using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.RemoveShiftBreak
{
    public class command_will : PlannedSupplyResponseCommandSpecification<RemoveShiftBreakRequest, 
                                                                            RemoveShiftBreakResponse, 
                                                                            RemoveShiftBreakFixture>
    {
        [TestMethod]
        [ExpectedException(typeof(InternalCorruptDataException))]
        public void throw_internal_server_error_on_corrupt_shift_data()
        {
            //Arrange
            fixture.contaminate_internal_shift_details();

            // act
            fixture.execute_command();
        }
    }
}
