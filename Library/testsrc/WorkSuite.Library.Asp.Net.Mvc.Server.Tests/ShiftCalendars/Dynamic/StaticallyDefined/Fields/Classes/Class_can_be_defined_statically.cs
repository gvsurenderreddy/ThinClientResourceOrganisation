﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Fields.Classes
{
    [TestClass]
    public class Class_can_be_defined_statically
    {
        [TestMethod]
        public void but_it_is_an_empty_string_if_not_defined()
        {
            shift_calendar.classes.Should().NotBeNull();
            shift_calendar.classes.Should().BeEmpty();
        }

        [TestMethod]
        public void as_a_string()
        {
            var a_class = "A class";

            definition_builder
                .add_class(a_class)
                ;

            shift_calendar.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void from_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class(() => a_class)
                ;

            shift_calendar.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void by_adding_multiple_classes()
        {
            var a_class = "A class";
            var another_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class(a_class)
                .add_class(() => another_class)
                ;

            shift_calendar.classes.Should().Contain(a_class);
            shift_calendar.classes.Should().Contain(another_class);
        }

        private DynamicShiftCalendarStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return _helper.definition_builder; }
        }

        private ShiftCalendar shift_calendar
        {
            get { return _helper.shift_calendar; }
        }

        [TestInitialize]
        public void before_each_test()
        {
            _helper = new DynamicShiftCalendarStaticDefinitionHelper<AModel>
            {
                model = new AModel()
                {
                    a_start_date = DateTime.Now.Date,
                    the_range_returned = ShiftCalendarRange.Week,
                }
            };

            //Start date and range returned are mandatory
            _helper.definition_builder.start_date(m => m.a_start_date);
            _helper.definition_builder.number_of_days_range(m => m.the_range_returned);
        }

        private DynamicShiftCalendarStaticDefinitionHelper<AModel> _helper;
    }
}