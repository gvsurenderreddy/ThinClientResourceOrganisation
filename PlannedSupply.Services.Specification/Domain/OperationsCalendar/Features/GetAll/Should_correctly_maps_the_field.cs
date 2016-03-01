using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.GetAll
{
    [TestClass]
    public class Should_correctly_maps_the_field
                        : GetAllFixture
    {
        [TestMethod]
        public void calendar_name()
        {
            OperationsCalendars.OperationalCalendar operational_calendar = add_operations_calendar()
                                                    .calendar_name("Calendar name")
                                                    .entity;

            Assert.IsTrue(_get_all_operations_calendar_details.execute().result.First().calendar_name == operational_calendar.calendar_name);
        }
    }
}