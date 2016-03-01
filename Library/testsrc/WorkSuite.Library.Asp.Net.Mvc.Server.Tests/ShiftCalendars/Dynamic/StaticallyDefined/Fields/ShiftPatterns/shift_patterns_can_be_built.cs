using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Fields.ShiftPatterns
{
    [TestClass]
    public class shift_patterns_can_be_built
    {
        [TestMethod]
        public void shift_pattern_count_is_correct()
        {

            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.Count().Should().Be(model.a_collection_of_shift_patterns.Count());
        }

        [TestMethod]
        public void id_property_is_correct()
        {

            model.a_collection_of_shift_patterns = new List<IShiftPattern>()
            {
                new AShiftPattern()
                {
                    number_of_resources = 5,
                    shift_calendar_pattern_name = "Pattern A",
                    time_allocation_occurrences = new List<ITimeAllocationOccurrence>() {},
                }
            };

            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.First().shift_calendar_pattern_id.Should().Be(model.a_collection_of_shift_patterns.First().shift_calendar_pattern_id);
        }

        [TestMethod]
        public void number_of_resources_property_are_correct()
        {

            model.a_collection_of_shift_patterns = new List<IShiftPattern>()
            {
                new AShiftPattern()
                {
                    number_of_resources = 5,
                    shift_calendar_pattern_name = "Pattern A",
                    time_allocation_occurrences = new List<ITimeAllocationOccurrence>() {},
                }
            };

            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.First().number_of_resources.Should().Be(model.a_collection_of_shift_patterns.First().number_of_resources);
        }

        [TestMethod]
        public void pattern_name_property_is_correct()
        {
            model.a_collection_of_shift_patterns = new List<IShiftPattern>()
            {
                new AShiftPattern()
                {
                    number_of_resources = 5,
                    shift_calendar_pattern_name = "Pattern A",
                    time_allocation_occurrences = new List<ITimeAllocationOccurrence>() {},
                }
            };

            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.First().name.Should().Be(model.a_collection_of_shift_patterns.First().shift_calendar_pattern_name);
        }

        [TestMethod]
        public void time_blocks_count_is_7_on_weekly_view()
        {
            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.First().time_blocks.Count().Should().Be(7);
        }

        [TestMethod]
        public void time_blocks_count_is_28_on_4_weekly_view()
        {
            model.the_range_returned = ShiftCalendarRange.FourWeek;

            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.First().time_blocks.Count().Should().Be(28);
        }

        [TestMethod]
        public void time_segment_percentage_is_not_greater_than_100_percent()
        {

            model.a_start_date = DateTime.Now.Date;

            model.a_collection_of_shift_patterns = new List<IShiftPattern>()
            {
                new AShiftPattern()
                {
                    number_of_resources = 5,
                    shift_calendar_pattern_name = "Pattern A",
                    time_allocation_occurrences = new List<ITimeAllocationOccurrence>()
                    {
                        new ATimeAllocationOccurrence()
                        {
                            colour = "a colour",
                            duration_in_seconds = 3600,
                            start_date = model.a_start_date.AddDays(2),
                            start_time_in_seconds_from_midnight = 0,
                            title = "a title"
                        },
                        new ATimeAllocationOccurrence()
                        {
                            colour = "a colour",
                            duration_in_seconds = 32400,
                            start_date = model.a_start_date.AddDays(3),
                            start_time_in_seconds_from_midnight = 3600,
                            title = "a title"
                        }
                    },
                }
            };

            definition_builder
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.shift_patterns.First().time_blocks.First().time_segments.Select(ts => ts.percentage_of_day).Sum().Should().BeLessThan(100);
        }



        private AModel model
        {
            get { return helper.model; }
        }

        private DynamicShiftCalendarStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }

        private ShiftCalendar shift_calendar
        {
            get { return helper.shift_calendar; }
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicShiftCalendarStaticDefinitionHelper<AModel>
            {
                model = new AModel
                {
                    a_start_date = DateTime.Now.Date,
                    the_range_returned = ShiftCalendarRange.Week,
                    a_collection_of_shift_patterns = new List<IShiftPattern>()
                    {
                        new AShiftPattern()
                        {
                            number_of_resources = 5,
                            shift_calendar_pattern_name = "Pattern A",
                            time_allocation_occurrences = new List<ITimeAllocationOccurrence>() {},
                        },
                        new AShiftPattern()
                        {
                            number_of_resources = 3,
                            shift_calendar_pattern_name = "Pattern B",
                            time_allocation_occurrences = new List<ITimeAllocationOccurrence>() {},
                        }

                    }
                }
            };

            //Start date and range returned are mandatory
            helper.definition_builder.start_date(m => m.a_start_date);
            helper.definition_builder.number_of_days_range(m => m.the_range_returned);
        }

        private DynamicShiftCalendarStaticDefinitionHelper<AModel> helper;
    }
}
