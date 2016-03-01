using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.eventHandlers.sicknessCreated
{
     [TestClass]
    public class sickness_created_event_will : SicknessCreatedEventSpecification
    {
        [TestMethod]
        public void commit_changes()
        {
            // Arrange
            var event_to_handle = fixture.CreateEvent();

            // Act
            fixture.sickness_created_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(true, fixture.changes_were_commited());
        }

        [TestMethod]
        public void create_sickness_items_in_repository()
        {
            // Arrange
            var event_to_handle = fixture.CreateEvent();

            // Act
            fixture.sickness_created_event_handler.handle(event_to_handle);

            // Assert
            Assert.AreEqual(1, fixture.count_matching_events_in_repository(event_to_handle));
        }

        [TestMethod]
        public void when_duplicate_dates_are_entered_for_sickness()
        {
            // Arrange
            fixture.add_to_repository();
            DateTime add_date = new DateTime(2015, 4, 1);
            var event_to_handle = fixture.CreateEvent();

            // Act
            fixture.sickness_created_event_handler.handle(event_to_handle);
            // Assert
            Assert.AreEqual(false, fixture.changes_were_commited());

        }
    }
}
