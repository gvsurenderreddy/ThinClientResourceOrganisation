using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Fields.StartDate
{
    [TestClass]
    public class start_date_can_be_defined
    {
        [TestMethod]
        public void calendar_header_starts_on_selected_start_date()
        {
            model.a_start_date = DateTime.Now.AddDays(-58).Date;

            definition_builder
                .start_date(m=>m.a_start_date)
                .patterns(m => m.a_collection_of_shift_patterns)
                ;

            shift_calendar.shift_pattern_grid.days.First().Should().Be(model.a_start_date);
        }

        [TestMethod]
        public void calendar_header_starts_on_selected_start_date_even_when_there_are_no_patterns()
        {
            model.a_start_date = DateTime.Now.AddDays(-58).Date;

            definition_builder
                .start_date(m => m.a_start_date)
                .patterns(m => Enumerable.Empty<IShiftPattern>())
                ;

            shift_calendar.shift_pattern_grid.days.First().Should().Be(model.a_start_date);
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
