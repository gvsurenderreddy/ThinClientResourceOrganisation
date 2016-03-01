using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Fields.Classes
{
    [TestClass]
    public class Class_can_be_defined_statically
    {
        [TestMethod]
        public void but_it_is_an_empty_string_if_not_defined()
        {
            lister.classes.Should().NotBeNull();
            lister.classes.Should().BeEmpty();
        }

        [TestMethod]
        public void as_a_string()
        {
            var a_class = "a class";

            definition_builder
                .add_class(a_class)
                ;

            lister.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void from_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class(() => a_class)
                ;

            lister.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void by_adding_multiple_classes()
        {
            var a_class = DateTime.Now.Ticks.ToString();
            var another_class = "a class";

            definition_builder
                .add_class(another_class)
                .add_class(() => a_class)
                ;

            lister.classes.Should().Contain(a_class);
            lister.classes.Should().Contain(another_class);
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