using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetSingleDetails;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.StartDate
{
    [TestClass]
    public class get_single_occurrence_details_will : GetSingleOccurrenceDetailsSpecification
    {
        [TestMethod]
        public void correctly_map_the_start_date_field()
        {
            var expected_start_date = fixture.seed_request_start_date(DateTime.Now.AddDays(-5).Date);

            fixture.execute_query();

            var response = fixture.response.result;

            Assert.AreEqual(expected_start_date, response.start_date);
        }

    }
}
