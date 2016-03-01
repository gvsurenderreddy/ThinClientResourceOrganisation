using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetAllDetails;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.Colour
{
    [TestClass]
    public class get_all_occurrences_details_will : GetAllOccurrencesDetailsSpecification
    {
        [TestMethod]
        public void correctly_map_the_colour_field()
        {
            var expected_colour = fixture.seed_request_colour(120, 180, 200);

            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(expected_colour.R, response.colour.R);
            Assert.AreEqual(expected_colour.G, response.colour.G);
            Assert.AreEqual(expected_colour.B, response.colour.B);
        }
    }
}
