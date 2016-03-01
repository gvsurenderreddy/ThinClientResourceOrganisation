using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Fields.Classes {

    [TestClass]
    public class Classes_can_be_defined_statically {

        [TestMethod]
        public void can_add_as_a_string() {

            definition_builder
                .add_class( "a class" )
                ;

            header.classes.Should().Contain("a class");
        }

        [TestMethod]
        public void can_add_as_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class(() => a_class)
                ;

            header.classes.Should().Contain(a_class);
        }


        [TestMethod]
        public void can_add_multiple_classes()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class("a class")
                .add_class(() => a_class)
                ;
            
            header.classes.Should().Contain("a class");
            header.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void is_an_empty_collection_if_none_specified()
        {

            header.classes.Should().NotBeNull();
            header.classes.Should().BeEmpty();
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicContentHeaderStaticDefinitionHelper<Helpers.AModel>();
            helper.model = new Helpers.AModel();
        }

        private DynamicContentHeaderStaticDefinitionHelper<Helpers.AModel> helper;
        private Helpers.AModel model
        {
            get { return helper.model; }
        }
        private DynamicContentHeaderStaticDefinitionBuilder<Helpers.AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }
        private ContentHeader header
        {
            get { return helper.header; }
        }

    }

}