using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.AggregateRoot.FindOrCreate
{
    [TestClass]
    public class command_will : FindOrCreateAndReturnTimeAllocationSpecification
    {
        [TestMethod]
        public void create_a_time_allocation_when_repository_is_empty()
        {
            fixture.execute_command();

            fixture.response
                .Match(
                was_successful: success_response =>
                {
                    var time_allocation = success_response.time_allocation;
                    Assert.AreEqual(fixture.existing_time_allocations.Single(), time_allocation);
                    
                },
                had_errors: error_response => Assert.Fail("We should not be getting any errors whatsoever"));
        }

        [TestMethod]
        public void return_the_existing_time_allocation_when_a_match_exists_in_the_repository()
        {
            var existing_time_allocation = fixture.seed_a_time_allocation_with_this_signature_before_command_executes(fixture.request);

            fixture.execute_command();

            fixture.response
                .Match(
                was_successful: success_response =>
                {
                    var time_allocation = success_response.time_allocation;
                    Assert.AreEqual(existing_time_allocation, time_allocation);
                },
                had_errors: error_response => Assert.Fail("We should not be getting any errors whatsoever"));
        }
    }
}
