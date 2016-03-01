using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.holidayRemoved
{
    [TestClass]
    public class holiday_removed_event_will : HolidayRemovedEventSpecification
    {
        [TestMethod]
        public void commit_changes()
        {
            fixture.add_to_repository();
            // Arrange
            DateTime add_date = new DateTime(2015, 4, 1);
            var event_to_handle = fixture.CreateEvent(add_date);

            // Act
            fixture.holiday_removed_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(true, fixture.changes_were_commited());

        }

        [TestMethod]
        public void test_for_items_count()
        {
            fixture.add_to_repository();
            // Arrange
            DateTime add_date = new DateTime(2015, 4, 1);
            var event_to_handle = fixture.CreateEvent(add_date.AddDays(1));

            // Act
            fixture.holiday_removed_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(0, fixture.count_matching_events_in_repository(event_to_handle));

        }

        [TestMethod]
        public void test_when_holiday_does_not_exists()
        {
            // Arrange
            DateTime add_date = new DateTime(2015, 4, 1);
            var event_to_handle = fixture.CreateEvent(add_date.AddDays(1));

            // Act
            fixture.holiday_removed_event_handler.handle(event_to_handle);
            // Assert
            Assert.AreEqual(false, fixture.changes_were_commited());

        }
    }
}
