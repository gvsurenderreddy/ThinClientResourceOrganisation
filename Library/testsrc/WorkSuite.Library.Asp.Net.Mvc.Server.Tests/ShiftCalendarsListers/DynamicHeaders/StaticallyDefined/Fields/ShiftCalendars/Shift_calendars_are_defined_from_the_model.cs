using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Fields.ShiftCalendars
{
    [TestClass]
    public class Shift_calendars_are_defined_from_the_model
    {
        [TestMethod]
        public void shift_calendars_are_loaded_from_the_model_via_the_deinition()
        {
            var a_shift_calendar = new ShiftCalendar
            {
                title = "A shift calendar"
            };

            model.a_shift_calendar = a_shift_calendar;

            definition_builder
                .get_calendars_via(m =>
                {
                    var shift_calendars = new List<ShiftCalendar>();
                    shift_calendars.Add(m.a_shift_calendar);
                    return shift_calendars;
                })
                ;

            var shift_calendar = lister.all_shift_calendars.First();

            shift_calendar.title.Should().Be(a_shift_calendar.title);
        }

        private AModel model
        {
            get { return _helper.model; }
        }

        private DynamicShiftCalendarsListerStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return _helper.definition_builder; }
        }

        private ShiftCalendarsLister lister
        {
            get { return _helper.lister; }
        }

        [TestInitialize]
        public void before_each_test()
        {
            _helper = new DynamicShiftCalendarsListerStaticDefinitionHelper<AModel>();
            _helper.model = new AModel();
        }

        private DynamicShiftCalendarsListerStaticDefinitionHelper<AModel> _helper;
    }
}