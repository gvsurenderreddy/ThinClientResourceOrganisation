using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Actions.Fields.Title
{
    [TestClass]
    public class Title_can_be_defined_from_the_model
    {
        public class AnAction
                        : CommonActionDefinition
        {
            public override string title
            {
                get { return "Action title"; }
            }

            public override string action_class
            {
                get { return "Action class"; }
            }

            public override string action_name
            {
                get { return "action name"; }
            }
        }

        // done: from the a property of the model

        [TestMethod]
        public void from_the_a_property_of_the_model()
        {
            model.a_title = "A title dsasdasda";

            actions_definition_builder
                .new_action<AnAction>()
                .title(m => m.a_title)
                .add()
                ;

            header.actions.Should().Contain(a => a.title == model.a_title);
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

        private DynamicContentHeaderActionsStaticDefintionBuilder<Helpers.AModel> actions_definition_builder
        {
            get { return helper.actions_definition_builder; }
        }

        private ContentHeader header
        {
            get { return helper.header; }
        }
    }
}