using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetAll;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Fields.duration
{
    [TestClass]
    public class get_all_shift_breaks_will : GetAllShiftBreaksSpecification
    {
        [TestMethod]
        public void correctly_map_the_duration_field()
        {
            var expected_break = fixture.seed_request_break(120, 180, true);

            fixture.execute_query();

            var response = fixture.response.result.First();

            Assert.AreEqual(expected_break.duration.hours, response.duration.hours);
            Assert.AreEqual(expected_break.duration.minutes, response.duration.minutes);
        }
    }
}
