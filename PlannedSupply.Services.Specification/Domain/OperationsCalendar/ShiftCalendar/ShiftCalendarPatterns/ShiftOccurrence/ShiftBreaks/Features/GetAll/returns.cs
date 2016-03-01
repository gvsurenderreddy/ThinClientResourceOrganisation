using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetAll
{
    [TestClass]
    public class returns : GetAllShiftBreaksSpecification
    {
        [TestMethod]
        public void the_correct_shift_break()
        {
            var expected_break = fixture.seed_request_break(20, 300, true);

            fixture.execute_query();

            var response = fixture.response.result.First();

            Assert.AreEqual(expected_break.shift_break_id, response.shift_break_id);
        }

        [TestMethod]
        public void the_correct_shift_break_count()
        {
            fixture.seed_request_break(20, 300, true);

            fixture.seed_request_break(400, 300, true);

            fixture.execute_query();

            var response = fixture.response.result;

            Assert.IsTrue(response.Count() == 2);
        }

        [TestMethod]
        public void an_empty_set_when_no_shift_breaks_exist()
        {
            fixture.execute_query();

            var response = fixture.response.result;

            Assert.IsTrue(!response.Any());
        }
    }
}