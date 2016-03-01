using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.AddHolidayWhenHolidayCreated
{
    [TestClass]
    public class holiday_created_event_will : HolidayCreatedEventSpecification
    {

        [TestMethod]
        public void commit_changes()
        {
            // Arrange
            var event_to_handle = fixture.CreateEvent();

            // Act
            fixture.holiday_created_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(true, fixture.changes_were_commited());
        }

        [TestMethod]
        public void create_holiday_items_in_repository()
        {
            // Arrange
            var event_to_handle = fixture.CreateEvent();

            // Act
            fixture.holiday_created_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(1, fixture.count_matching_events_in_repository(event_to_handle));
        }

        [TestMethod]
        public void not_create_duplicate_holidays()
        {
            // Arrange
            var event_to_handle = fixture.CreateEvent();

            // Act
            fixture.holiday_created_event_handler.handle(event_to_handle);
            fixture.holiday_created_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(1, fixture.count_matching_events_in_repository(event_to_handle));
        }
    }
}
