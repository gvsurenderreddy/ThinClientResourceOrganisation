using System.Linq;
using Content.Services.PlannedSupply.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit
{
    [TestClass]
    public class EditSingleShiftOccurrence_will : PlannedSupplyResponseCommandSpecification<EditSingleShiftOccurrenceRequest
                                                                                               , EditSingleShiftOccurrenceResponse
                                                                                               , EditSingleShiftOccurrenceFixture>
    {

        [TestMethod]
        public void validate_against_a_clash_between_the_shift_and_its_breaks()
        {
            // Arrange
            var time_allocation_for_request = fixture.get_backing_time_allocation(fixture.request);

            fixture.ensure_a_break_ends_1_minute_before_the_end_of_this_time_allocation(time_allocation_for_request);

            //reduce the duration of the shift request by just a little (2 minutes: 120 seconds) to cause a clash
            fixture.request.duration = (time_allocation_for_request.duration_in_seconds - 120).to_duration_request();

            //Act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.response.messages.Count() == 3);
            Assert.IsTrue(fixture.response.messages.Select(msg=>msg.field_name).Contains("duration.hours"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("duration.minutes"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.message).Contains(WarningMessages.warning_03_0030));           

        }


        [TestMethod]
        public void if_updated_time_allocation_is_exist_changed_to_refer_to_an_existing_time_allocaton()
        {
            // Arrange
            var time_allocation_for_request = fixture.get_backing_time_allocation(fixture.request);

            // Act
            fixture.execute_command();


            var time_allocation_for_response = fixture.get_backing_time_allocation(fixture.response.result);

            //Assert
            Assert.AreEqual(time_allocation_for_request, time_allocation_for_response);

        }

        [TestMethod]
        public void id_uodated_time_allocation_is_not_exist_changed_to_refer_to_the_new_time_allocaton()
        {
            // Arrange
            fixture.request.shift_title = "a very very different title";

            var time_allocation_for_request = fixture.get_backing_time_allocation(fixture.request);

            // Act
            fixture.execute_command();

            var time_allocation_for_response = fixture.get_backing_time_allocation(fixture.response.result);

            //Assert
            Assert.AreNotEqual(time_allocation_for_request, time_allocation_for_response);

        }

        [TestMethod]
        [ExpectedException(typeof(InternalCorruptDataException))]
        public void throw_internal_server_error_on_corrupt_internal_break()
        {
            fixture.contaminate_internal_break();
            fixture.execute_command();
        }
    }
}