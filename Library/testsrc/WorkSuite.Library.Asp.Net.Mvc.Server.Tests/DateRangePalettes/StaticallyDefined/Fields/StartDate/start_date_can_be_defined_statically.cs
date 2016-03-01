﻿using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Fields.StartDate {

    [TestClass]
    public class start_date_can_be_defined_statically {
        
        // done: as static text
        // done: from an expression

        [TestMethod]
        public void as_static_text()
        {
            
            var date = DateTime.Now.Date;

            definition_builder
                .selected_start_date(date)
                .calendar_start_date(date)
                ;


            date_range_palette.calendar.dates
                                    .SelectMany(dt => dt)
                                        .Any(dt => dt.date == date)
                                            .Should()
                                                .Be(true);
        }

        [TestMethod]
        public void from_an_expression() {

            var date = DateTime.Now.Date;

            definition_builder
                .selected_start_date(() => date)
                .calendar_start_date(() => date)
                ;

            date_range_palette.calendar.dates
                                    .SelectMany(dt => dt)
                                        .Any(dt => dt.date == date)
                                            .Should()
                                                .Be(true);
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
                .selected_start_date(DateTime.Now.AddDays(5).Date)
                .calendar_start_date(DateTime.Now.Date)
                .selected_range(m => m.a_range)
                ;
        }

        private DynamicDateRangePaletteStaticDefinitionHelper<AModel> helper;
        private AModel model {
            get { return helper.model; }
        }
        private DynamicDateRangePaletteStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }
        private DateRangePalette date_range_palette {
            get { return helper.date_range_palette; }
        }
    }
}