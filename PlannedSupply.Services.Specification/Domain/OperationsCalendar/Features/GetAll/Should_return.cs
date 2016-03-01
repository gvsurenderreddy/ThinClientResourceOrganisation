using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.GetAll
{
    [TestClass]
    public class Should_return
                    : GetAllFixture
    {
        [TestMethod]
        public void all_operations_calendars()
        {
            add_operations_calendar();
            add_operations_calendar();

            Assert.IsTrue( _get_all_operations_calendar_details.execute().result.Count() == 2 );
        }

        [TestMethod]
        public void an_empty_set_when_there_are_no_operations_calendars()
        {
            Assert.IsTrue( !_get_all_operations_calendar_details.execute().result.Any() );
        }
    }
}