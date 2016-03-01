using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetSingleDetails;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.Duration
{
    [TestClass]
    public class get_single_occurrence_details_will : GetSingleOccurrenceDetailsSpecification
    {
        [TestMethod]
        public void correctly_map_the_duration_field()
        {
            var expected_duration = fixture.seed_request_duration(1400);

            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(expected_duration, response.duration);
        }

    }
}
