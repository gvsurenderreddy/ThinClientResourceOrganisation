using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.OperationsCalendarDetails.OperationsCalendarSummary;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.GetByIdAndDateRange
{
    [TestClass]
    public class Should_correctly_maps_the_field : GetByIdAndDateRangeFixture
    {
        [TestMethod]
        public void calendar_name()
        {
            var operational_calendar = add_operations_calendar().entity;

            var response = get_operations_calendar_summary.execute(new GetOperationsCalendarAggregateOverRangeRequest { operations_calendar_id = operational_calendar.id, start_date = DateTime.Now.Date });
            Assert.IsTrue(operational_calendar.calendar_name == response.result.calendar_name);
        }

        [TestMethod]
        public void start_date_returned_should_match_the_request()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = DateTime.Now.AddDays(-58)
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(request.start_date == response.result.start_date);
        }


        [TestMethod]
        public void shift_calendar_name()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = DateTime.Now.Date
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(operational_calendar.ShiftCalendars.First().calendar_name == response.result.all_shift_calendars_details.First().calendar_name);
        }

        [TestMethod]
        public void weekly_range_returned_correctly()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = DateTime.Now.Date,
                 range_type = ShiftCalendarRange.Week
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(request.range_type == response.result.range_returned);
        }

        [TestMethod]
        public void four_weekly_range_returned_correctly()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = DateTime.Now.Date,
                range_type = ShiftCalendarRange.FourWeek
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(request.range_type == response.result.range_returned);
        }

        [TestMethod]
        public void shift_calendar_pattern_count()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = the_start_date_context
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(operational_calendar
                                        .ShiftCalendars.First()
                                                            .ShiftCalendarPatterns.Count() == response.result.all_shift_calendars_details.First()
                                                                                                                                            .shift_calendar_patterns.Count());
        }

        [TestMethod]
        public void shift_calendar_pattern_name()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = the_start_date_context
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(operational_calendar
                                        .ShiftCalendars.First()
                                                            .ShiftCalendarPatterns.First()
                                                                                    .name == response.result.all_shift_calendars_details.First()
                                                                                                                                            .shift_calendar_patterns.First()
                                                                                                                                                                                    .shift_calendar_pattern_name);
        }

        

        [TestMethod]
        public void shift_occurrence_count()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = the_start_date_context
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(operational_calendar
                                        .ShiftCalendars.First()
                                                            .ShiftCalendarPatterns.First()
                                                                                    .TimeAllocationOccurrences
                                                                                                        .Count() == response.result.all_shift_calendars_details.First()
                                                                                                                                                                .shift_calendar_patterns.First()
                                                                                                                                                                                                    .time_allocation_occurrences
                                                                                                                                                                                                    .Count());
        }

        [TestMethod]
        public void shift_occurrence_name()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = the_start_date_context
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(the_time_allocation.title == response.result.all_shift_calendars_details.First().shift_calendar_patterns.First().time_allocation_occurrences.First().title);
        }


        [TestMethod]
        public void shift_calendar_pattern_resource_count()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = the_start_date_context
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(operational_calendar
                                        .ShiftCalendars.First()
                                                            .ShiftCalendarPatterns.First()
                                                                                    .number_of_resources == response.result.all_shift_calendars_details.First()
                                                                                                                                            .shift_calendar_patterns.First()
                                                                                                                                                                     .number_of_resources);
        }

        [TestMethod]
        public void shift_calendar_pattern_resource_count_actual()
        {
            var operational_calendar = add_operations_calendar().entity;

            var request = new GetOperationsCalendarAggregateOverRangeRequest
            {
                operations_calendar_id = operational_calendar.id,
                start_date = the_start_date_context
            };

            var response = get_operations_calendar_summary.execute(request);
            Assert.IsTrue(operational_calendar
                                        .ShiftCalendars.First()
                                                            .ShiftCalendarPatterns.First().ResourceAllocations.Count()
                                                                                     == response.result.all_shift_calendars_details.First()
                                                                                                                                         .shift_calendar_patterns.First()
                                                                                                                                                                  .resource_allocation_summary);
        }
    }
}