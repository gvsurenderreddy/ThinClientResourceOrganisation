using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.RemoveHolidaysWhenEmployeeRemoved
{
    [TestClass]
    public class event_handler_will : RemoveEmployeeHolidaysWhenEmployeeRemovedSpecification
    {
        [TestMethod]
        public void fixture_will_successfully_seed_holidays_for_the_employee()
        {
            //This test is a Meta-Test
            //Its purpose is to ensure that the fixture works the way it is intended to

            //Arrange
            fixture.seed_holidays_for_a_fake_new_employee();

            //Assert
            Assert.IsTrue(fixture.number_of_holidays_for_employee() > 0);
        }

        [TestMethod]
        public void successfully_remove_all_holiday_items_for_an_employee_when_triggered()
        {
            //Arrange
            fixture.seed_holidays_for_a_fake_new_employee();

            //Act
            var an_event = fixture.trigger_employee_removed_event();
            fixture.handle_event(an_event);

            //Assert
            Assert.IsTrue(fixture.number_of_holidays_for_employee() == 0);
        }

        [TestMethod]
        public void successfully_execute_even_when_there_are_no_holiday_items_for_the_specified_employee()
        {
            //Arrange
            //No holidays will be seeded.

            //Act
            var an_event = fixture.trigger_employee_removed_event();
            fixture.handle_event(an_event);

            //Assert
            Assert.IsTrue(fixture.number_of_holidays_for_employee() == 0);
        }
    }
}
