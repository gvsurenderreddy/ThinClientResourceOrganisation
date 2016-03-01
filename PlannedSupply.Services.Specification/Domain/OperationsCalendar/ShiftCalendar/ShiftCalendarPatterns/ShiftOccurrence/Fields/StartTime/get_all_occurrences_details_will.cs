using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetAllDetails;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.StartTime
{
    [TestClass]
    public class get_all_occurrences_details_will : GetAllOccurrencesDetailsSpecification
    {
        [TestMethod]
        public void correctly_map_the_start_time_field()
        {
            var expected_start_time_string = fixture.seed_request_start_time(300);

            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(expected_start_time_string, response.start_time);
        }

    }
}
