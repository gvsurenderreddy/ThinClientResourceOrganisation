using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Fields.Title
{
    [TestClass]
    public class Title_can_be_defined_statically
    {
        [TestMethod]
        public void but_it_is_an_empty_string_if_not_defined()
        {
            lister.title.Should().BeEmpty();
        }

        [TestMethod]
        public void as_a_string()
        {
            var a_title = "A title";

            definition_builder
                .title(a_title)
                ;

            lister.title.Should().Be(a_title);
        }

        [TestMethod]
        public void from_an_expression()
        {
            var title = DateTime.Now.Ticks.ToString();

            definition_builder
                .title(() => title)
                ;

            lister.title.Should().Be(title);
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