using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.EditAll
{
    [TestClass]
    public class CommandWill
                        : PlannedSupplyResponseCommandSpecification < EditAllShiftOccurrencesRequest
                                                                    , EditAllShiftOccurrencesResponse
                                                                    , EditAllShiftOccurrencesFixture>
    {
        [TestMethod]
        [ExpectedException(typeof(InternalCorruptDataException))]
        public void throw_internal_server_error_on_corrupt_shift_data()
        {
            //Arrange
            fixture.contaminate_internal_break();

            // act
            fixture.execute_command();
        }
         
    }
}