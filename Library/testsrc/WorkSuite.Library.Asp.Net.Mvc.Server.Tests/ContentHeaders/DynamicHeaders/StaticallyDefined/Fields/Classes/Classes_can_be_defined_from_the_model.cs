using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Fields.Classes {

    [TestClass]
    public class Classes_can_be_defined_from_the_model {


        [TestMethod]
        public void from_the_a_property_of_the_model () {
            model.a_class = "A class";

            definition_builder
                .add_class( m => m.a_class )
                ;

            header.classes.Should().Contain(model.a_class);
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