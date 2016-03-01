using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Feature 
{

    [TestClass]
    public class date_range_palette_will
    {

        [TestMethod]
        public void build_6_weeks_of_data() {

            model.a_start_date_time = RandomDay().Date;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates.Count()
                                                .Should()
                                                    .Be(6);
        }

        [TestMethod]
        public void build_the_first_day_of_the_week_correctly()
        {

            model.a_start_date_time = RandomDay().Date;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates.First()
                                                .First()
                                                    .date
                                                        .DayOfWeek
                                                            .Should()
                                                                .Be(DayOfWeek.Monday);
        }

        [TestMethod]
        public void build_the_last_day_of_the_week_correctly()
        {

            model.a_start_date_time = RandomDay().Date;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates.ElementAt(4)
                                                .Last()
                                                    .date
                                                        .DayOfWeek
                                                            .Should()
                                                                .Be(DayOfWeek.Sunday);
        }

        [TestMethod]
        public void build_7_days_as_highlighted_correctly_when_selected_date_and_calendar_start_date_are_within_same_month_and_selected_range_is_7_days()
        {

            model.a_start_date_time = RandomDay().Date;
            model.a_range = WTS.WorkSuite.Library.DomainTypes.ShiftCalendarRange.Week;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates
                                .SelectMany(dt => dt.Where(d=>d.is_selected))
                                    .Count()
                                        .Should()
                                            .Be(7);

            
        }

        [TestMethod]
        public void build_28_days_as_highlighted_correctly_when_selected_date_and_calendar_start_date_are_within_same_month_and_selected_range_is_28_days()
        {

            model.a_start_date_time = new DateTime(2014, 1, 1);//1st of January definitely has 28 days
            model.a_range = WTS.WorkSuite.Library.DomainTypes.ShiftCalendarRange.FourWeek;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates
                                .SelectMany(dt => dt.Where(d => d.is_selected))
                                    .Count()
                                        .Should()
                                            .Be(28);


        }

        [TestMethod]
        public void build_0_days_as_highlighted_correctly_when_selected_date_and_calendar_start_date_are_not_within_same_month()
        {

            model.a_start_date_time = RandomDay().Date;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time.AddMonths(3))
                ;

            date_range_palette.calendar.dates
                                .SelectMany(dt => dt.Where(d => d.is_selected))
                                    .Count()
                                        .Should()
                                            .Be(0);


        }

        [TestMethod]
        public void build_the_correct_number_of_days_for_any_given_month()
        {

            model.a_start_date_time = RandomDay().Date;

            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates
                                .SelectMany(dt => dt.Where(d => d.is_in_selected_month))
                                    .Count()
                                        .Should()
                                            .Be(DateTime.DaysInMonth(model.a_start_date_time.Year, model.a_start_date_time.Month));


        }

        [TestMethod]
        public void build_the_correct_number_of_days_for_a_leap_month()
        {
            model.a_start_date_time = RandomDay().Date.Month.February(2014);


            definition_builder
                .selected_start_date(m => m.a_start_date_time)
                .calendar_start_date(m => m.a_start_date_time)
                ;

            date_range_palette.calendar.dates
                                .SelectMany(dt => dt.Where(d => d.is_in_selected_month))
                                    .Count()
                                        .Should()
                                            .Be(DateTime.DaysInMonth(model.a_start_date_time.Year, model.a_start_date_time.Month));


        }



        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicDateRangePaletteStaticDefinitionHelper<AModel>
            {
                model = new AModel()
            };

            model.a_range = WTS.WorkSuite.Library.DomainTypes.ShiftCalendarRange.Week;

            definition_builder
                .selected_start_date(RandomDay().Date)
                .calendar_start_date(RandomDay().Date)
                .selected_range(m => m.a_range)
                ;
        }

        private DynamicDateRangePaletteStaticDefinitionHelper<AModel> helper;
        private AModel model
        {
            get { return helper.model; }
        }
        private DynamicDateRangePaletteStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }
        private DateRangePalette date_range_palette
        {
            get { return helper.date_range_palette; }
        }

        Func<DateTime> RandomDay
        {
            get
            {
                var start = new DateTime(1995, 1, 1);
                var gen = new Random();
                var range = ((TimeSpan)(DateTime.Today - start)).Days;
                return () => start.AddDays(gen.Next(range));
            }
            
        }
    }

}