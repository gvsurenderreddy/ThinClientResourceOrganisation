using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetSingleDetails
{
    [TestClass]
    public class returns : GetSingleOccurrenceDetailsSpecification
    {
        [TestMethod]
        public void the_correct_single_shift_occurrence()
        {
            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(fixture.request.shift_occurrence_id, response.shift_occurrence_id);
        }
    }
}