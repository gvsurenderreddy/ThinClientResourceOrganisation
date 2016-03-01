using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class CheckClashingshiftsBetweenPeerSpecification<P, Q, F>
                                      : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IClashingShiftFixture<P, Q>
    {
      //  preceding
        [TestMethod]
        public void when_old_shift_overlapped_by_new_shift_should_report_error()
        {

            var time_allocation = 
                fixture.shift_helper.add()
                       .shift_title("shift")
                       .colour(new RgbColour(45,56,67))
                       .start_time(new TimeRequest {hours = "23", minutes = "00"})
                       .duration(new DurationRequest {hours = "2", minutes = "0"})
                       .entity
                       ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() {hours = "1", minutes = "00"});


            fixture.execute_command();
           
            fixture.response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void when_old_shift_met_by_new_shift_should_not_report_error()
        {

            var time_allocation =
                fixture.shift_helper.add()
                       .shift_title("shift")
                       .colour(new RgbColour(45, 56, 67))
                       .start_time(new TimeRequest { hours = "23", minutes = "00" })
                       .duration(new DurationRequest { hours = "2", minutes = "0" })
                       .entity
                       ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "2", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void when_old_shift_preceded_by_new_shift_should_not_report_error()
        {

            var time_allocation =
                  fixture.shift_helper.add()
                         .shift_title("shift")
                         .colour(new RgbColour(45, 56, 67))
                         .start_time(new TimeRequest { hours = "23", minutes = "00" })
                         .duration(new DurationRequest { hours = "2", minutes = "0" })
                         .entity
                         ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "3", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeFalse();
        }

        //Following

        [TestMethod]
        public void when_old_shift_precedes_new_shift_should_not_report_error()
        {
            var time_allocation =
                  fixture.shift_helper.add()
                         .shift_title("shift")
                         .colour(new RgbColour(45, 56, 67))
                         .start_time(new TimeRequest { hours = "23", minutes = "00" })
                         .duration(new DurationRequest { hours = "2", minutes = "0" })
                         .entity
                         ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "3", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void when_old_shift_meets_by_new_shift_should_not_report_error()
        {
            var time_allocation =
                   fixture.shift_helper.add()
                          .shift_title("shift")
                          .colour(new RgbColour(45, 56, 67))
                          .start_time(new TimeRequest { hours = "23", minutes = "00" })
                          .duration(new DurationRequest { hours = "2", minutes = "0" })
                          .entity
                          ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "2", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void when_old_shift_overlaps_by_new_shift_should_report_error()
        {
            var time_allocation =
                   fixture.shift_helper.add()
                          .shift_title("shift")
                          .colour(new RgbColour(45, 56, 67))
                          .start_time(new TimeRequest { hours = "23", minutes = "00" })
                          .duration(new DurationRequest { hours = "3", minutes = "0" })
                          .entity
                          ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        // Adjacent

        [TestMethod]
        public void when_old_shift_finished_by_new_shift_should_report_error()
        {
            var time_allocation =
               fixture.shift_helper.add()
                      .shift_title("shift")
                      .colour(new RgbColour(45, 56, 67))
                      .start_time(new TimeRequest { hours = "23", minutes = "00" })
                      .duration(new DurationRequest { hours = "2", minutes = "0" })
                      .entity
                      ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();

        }

        [TestMethod]
        public void when_old_shift_contains_new_shift_should_report_error()
        {
            var time_allocation =
                  fixture.shift_helper.add()
                         .shift_title("shift")
                         .colour(new RgbColour(45, 56, 67))
                         .start_time(new TimeRequest { hours = "23", minutes = "00" })
                         .duration(new DurationRequest { hours = "3", minutes = "0" })
                         .entity
                         ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void when_old_shift_starts_new_shift_should_report_error()
        {
            var time_allocation =
                   fixture.shift_helper.add()
                          .shift_title("shift")
                          .colour(new RgbColour(45, 56, 67))
                          .start_time(new TimeRequest { hours = "24", minutes = "00" })
                          .duration(new DurationRequest { hours = "2", minutes = "0" })
                          .entity
                          ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "3", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void when_old_shift_equals_new_shift_should_report_error()
        {
            var time_allocation =
                               fixture.shift_helper.add()
                                      .shift_title("shift")
                                      .colour(new RgbColour(45, 56, 67))
                                      .start_time(new TimeRequest { hours = "24", minutes = "00" })
                                      .duration(new DurationRequest { hours = "2", minutes = "0" })
                                      .entity
                                      ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void when_old_shift_started_by_new_shift_should_report_error()
        {
            var time_allocation =
                               fixture.shift_helper.add()
                                      .shift_title("shift")
                                      .colour(new RgbColour(45, 56, 67))
                                      .start_time(new TimeRequest { hours = "24", minutes = "00" })
                                      .duration(new DurationRequest { hours = "3", minutes = "0" })
                                      .entity
                                      ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "1", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void when_old_shift_finishies_new_shift_should_report_error()
        {
            var time_allocation =
                               fixture.shift_helper.add()
                                      .shift_title("shift")
                                      .colour(new RgbColour(45, 56, 67))
                                      .start_time(new TimeRequest { hours = "24", minutes = "00" })
                                      .duration(new DurationRequest { hours = "3", minutes = "0" })
                                      .entity
                                      ;

            var pattern = create_occurrence_and_return_its_pattern(time_allocation);
            var next_date = pattern.Item1.TimeAllocationOccurrences.Single().start_date.Date.AddDays(1);
            const int next_date_non_clashing_start_time = 2;


            fixture.create_request(pattern.Item2, next_date, next_date_non_clashing_start_time);

            fixture.set_request_starts_time(new TimeRequest { hours = "00", minutes = "00" });
            fixture.set_request_duration(new DurationRequest() { hours = "2", minutes = "00" });

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }


        private Tuple<ShiftCalendarPattern, ShiftCalendarPatternIdentity> create_occurrence_and_return_its_pattern(TimeAllocation time_allocation)
        {
            var occurrence = new TimeAllocationOccurrence()
            {
                time_allocation = time_allocation,
                start_date = DateTime.Now.Date,
                id = -9111111
            };

            var pattern = new ShiftCalendarPattern()
            {
                id = -911,
                name = "a_name",
                priority = 1,
                number_of_resources = 3
            };
            pattern.TimeAllocationOccurrences.Add(occurrence);


            var calendar = new ShiftCalendar()
            {
                id = -911,
                calendar_name = "a_name"
            };
            calendar.ShiftCalendarPatterns.Add(pattern);


            var operation_calendar = operations_calendar_helper.add()
                .calendar_name("acalendar")
                .add_time_allocation(time_allocation)
                .add_shift_calendar(calendar)
                .entity;

            return new Tuple<ShiftCalendarPattern, ShiftCalendarPatternIdentity>(pattern, new ShiftCalendarPatternIdentity()
            {
                operations_calendar_id = operation_calendar.id,
                shift_calendar_id = calendar.id,
                shift_calendar_pattern_id = pattern.id
            });

        }

        public CheckClashingshiftsBetweenPeerSpecification()
        {
            operations_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
        }

        private readonly OperationsCalendarHelper operations_calendar_helper;

    }
}
