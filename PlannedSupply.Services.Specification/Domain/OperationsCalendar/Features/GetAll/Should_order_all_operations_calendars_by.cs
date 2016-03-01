using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.GetAll
{
    [TestClass]
    public class Should_order_all_operations_calendars_by
                            : GetAllFixture
    {
        [TestMethod]
        public void calendar_name()
        {
            add_operations_calendar()
                    .calendar_name("Very special season calendar");

            add_operations_calendar()
                    .calendar_name("Low season calendar");

            add_operations_calendar()
                    .calendar_name("High season calendar");

            var response = _get_all_operations_calendar_details.execute().result.ToList();

            response.Should().ContainInOrder( response.OrderBy( oc => oc.calendar_name ) );
        }
    }
}