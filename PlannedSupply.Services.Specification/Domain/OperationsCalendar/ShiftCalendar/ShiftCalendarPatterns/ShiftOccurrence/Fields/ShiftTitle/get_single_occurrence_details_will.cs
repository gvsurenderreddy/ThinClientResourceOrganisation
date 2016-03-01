using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetSingleDetails;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.ShiftTitle
{
    [TestClass]
    public class get_single_occurrence_details_will : GetSingleOccurrenceDetailsSpecification
    {
        [TestMethod]
        public void correctly_map_the_title_field()
        {
            var expected_title = fixture.seed_request_title("a title");

            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(expected_title, response.shift_title);
        }

    }
}
