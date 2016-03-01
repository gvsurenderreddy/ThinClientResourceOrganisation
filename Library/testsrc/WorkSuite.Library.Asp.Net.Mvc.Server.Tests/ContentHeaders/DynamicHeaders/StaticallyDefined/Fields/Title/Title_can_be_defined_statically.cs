using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Fields.Title {

    [TestClass]
    public class Title_can_be_defined_statically {
        
        // done: as static text
        // done: from an expression

        [TestMethod]
        public void as_static_text() {

            definition_builder
                .title("A title")
                ;

            header.title.Should().Be("A title");
        }

        [TestMethod]
        public void from_an_expression() {
            var title = DateTime.Now.Ticks.ToString();

            definition_builder
                .title( () => title )
                ;

            header.title.Should().Be( title );
        }

        [TestMethod]
        public void is_an_empty_string_if_not_defined() {

            header.title.Should().BeEmpty();
        }


        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicContentHeaderStaticDefinitionHelper<AModel>();
            helper.model = new AModel();
        }

        private DynamicContentHeaderStaticDefinitionHelper<AModel> helper;
        private AModel model {
            get { return helper.model; }
        }
        private DynamicContentHeaderStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }
        private ContentHeader header {
            get { return helper.header; }
        }
    }
}