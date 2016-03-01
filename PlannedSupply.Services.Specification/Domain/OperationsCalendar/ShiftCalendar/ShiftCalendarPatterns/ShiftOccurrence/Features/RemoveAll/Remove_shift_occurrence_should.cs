using System.Linq;
using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.RemoveAll
{
    [TestClass]
    public class Remove_shift_occurrence_should : CommandCommitedChangesSpecification < ShiftOccurrenceIdentity 
                                                                                      , RemoveAllShiftOccurrencesResponse 
                                                                                      , RemoveAllShiftOccurrenceFixture >
    {
        // All the occurrences should be remove .
        // After remove all occurrences should be show the confirmation message .
        // when remove occurrences the time allocation should not remove 
       
        [TestMethod]
        public void should_remove_all_occurrences()
        {
            // expected
            fixture.execute_command();
           

            //act
            var all_occurrences = the_repository.Entities.Single(e => e.id == fixture.request.operations_calendar_id)
                                      .ShiftCalendars.Single(s => s.id == fixture.request.shift_calendar_id)
                                      .ShiftCalendarPatterns.Single(p => p.id == fixture.request.shift_calendar_pattern_id)
                                      .TimeAllocationOccurrences.Select(oc => oc).ToList();
            //assert
            all_occurrences.Should().BeEmpty();


        }

        [TestMethod]
        public void after_remove_should_show_the_confirmation_message()
        {
            //expected 
            fixture.execute_command();
            //assert
            fixture.response.messages.Should().Contain(m => m.message == ConfirmationMessages.confirmation_04_0038);
        }

        [TestMethod]
        public void after_remove_all_occurrences_time_allocation_should_not_remove()
        {
            //expected
            var time_allocation = fixture.the_time_allocation_entity();

            //act
            fixture.execute_command();

            //assert
            time_allocation.Should().NotBeNull();
        }


        protected override void test_setup()
        {
            base.test_setup();
            the_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
        }

        // Improve: The entities should be accessed via the fixture not directly via the repository
        private FakeOperationsCalendarRepository the_repository;
    }
}