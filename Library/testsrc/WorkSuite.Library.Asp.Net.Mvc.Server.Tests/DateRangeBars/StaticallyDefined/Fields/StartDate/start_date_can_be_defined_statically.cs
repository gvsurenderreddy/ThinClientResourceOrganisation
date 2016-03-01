using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangeBars.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangeBars.StaticallyDefined.Fields.StartDate {

    [TestClass]
    public class start_date_can_be_defined_statically {
        
        // done: as static text
        // done: from an expression

        [TestMethod]
        public void as_static_text()
        {
            var start_date = new DateTime(2014, 1, 1);// 1st of Jan 2014


            definition_builder
                .start_date(start_date)
                ;

            date_range_bar.date_range_string.Should().Be("1 - 7 January 2014");
        }

        [TestMethod]
        public void from_an_expression() {

            var start_date = new DateTime(2014, 1, 1);// 1st of Jan 2014

            definition_builder
                .start_date(() => start_date)
                ;

            date_range_bar.date_range_string.Should().Be("1 - 7 January 2014");
        }


        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicDateRangeBarStaticDefinitionHelper<AModel>
            {
                model = new AModel()
            };

            definition_builder
                .date_range(m => ShiftCalendarRange.Week)
                ;
        }

        private DynamicDateRangeBarStaticDefinitionHelper<AModel> helper;
        private AModel model {
            get { return helper.model; }
        }
        private DynamicDateRangeBarStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }
        private DateRangeBar date_range_bar {
            get { return helper.date_range_bar; }
        }
    }
}