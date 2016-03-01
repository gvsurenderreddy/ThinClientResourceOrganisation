using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.GetDetailsById
{
    [TestClass]
    public class returns : GetShiftCalendarDetailsByIdSpecification
    {
        [TestMethod]
        public void the_correct_shift_calendar_identity()
        {
            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(fixture.request.shift_calendar_id, response.shift_calendar_id);
            Assert.AreEqual(fixture.request.operations_calendar_id, response.operations_calendar_id);
        }

        [TestMethod]
        public void the_correct_shift_calendar_name()
        {
            //Arrange
            const string seed_name = "another_calendar";

            fixture.set_shift_calendar_name_from_incoming_request(seed_name);

            //Act
            fixture.execute_query();

            var response = fixture.response.result;

            //Assert
            Assert.AreEqual(seed_name, response.calendar_name);
        }
    }
}
