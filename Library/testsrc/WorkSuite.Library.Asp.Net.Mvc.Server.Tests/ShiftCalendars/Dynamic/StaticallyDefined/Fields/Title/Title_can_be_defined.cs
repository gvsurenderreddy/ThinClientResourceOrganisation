using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Fields.Title
{
    [TestClass]
    public class Title_can_be_defined
    {
        [TestMethod]
        public void from_the_property_of_the_model()
        {
            model.a_title = "A title";

            definition_builder
                .title(m => m.a_title)
                ;

            shift_calendar.title.Should().Be(model.a_title);
        }

        private AModel model
        {
            get { return _helper.model; }
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