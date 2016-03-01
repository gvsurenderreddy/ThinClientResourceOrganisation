using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Remove
{
    [TestClass]
    public class Remove_shift_occurrence_should : CommandCommitedChangesSpecification<ShiftOccurrenceIdentity, RemoveShiftOccurrenceResponse, RemoveShiftOccurrenceFixture>
    {
        [TestMethod]
        public void remove_the_occurrence()
        {
            fixture.execute_command();

            the_repository.Entities.Single(e => e.id == fixture.request.operations_calendar_id)
                                    .ShiftCalendars.Single(s=>s.id == fixture.request.shift_calendar_id)
                                    .ShiftCalendarPatterns.Single(p=>p.id == fixture.request.shift_calendar_pattern_id)
                                    .TimeAllocationOccurrences.SingleOrDefault(o=>o.id == fixture.request.shift_occurrence_id)
                        .Should().BeNull();

        }

        //[TestMethod]
        //public void return_no_errors_if_the_entity_does_not_exist()
        //{
        //    the_repository.Entities.Single(e => e.id == fixture.request.operations_calendar_id)
        //                            .ShiftCalendars.Single(s => s.id == fixture.request.shift_calendar_id)
        //                            .ShiftCalendarPatterns.Single(p => p.id == fixture.request.shift_calendar_pattern_id)
        //                            .TimeAllocationOccurrences.Clear();

        //    fixture.execute_command();

        //    fixture.response.has_errors.Should().BeFalse();

        //}

        protected override void test_setup()
        {
            base.test_setup();
            the_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
        }

        private FakeOperationsCalendarRepository the_repository;
    }
}