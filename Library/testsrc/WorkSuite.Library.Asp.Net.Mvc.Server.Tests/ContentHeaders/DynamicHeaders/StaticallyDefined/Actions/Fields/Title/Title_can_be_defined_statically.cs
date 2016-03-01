using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Actions.Fields.Title
{
    [TestClass]
    public class Title_can_be_defined_statically
    {
        public class AnAction : CommonActionDefinition
        {
            public override string title
            {
                get { return "Action type"; }
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

        [TestMethod]
        public void from_the_action_definition()
        {
            var action_definition = new AnAction();

            actions_definition_builder
                .new_action<AnAction>()
                .add()
                ;

            header.actions.Should().Contain(a => a.title == action_definition.title);
        }

        [TestMethod]
        public void as_static_text()
        {
            var action_definition_template = new AnAction();
            var title = action_definition_template.title + "aaaaa";

            actions_definition_builder
                .new_action<AnAction>()
                .title(title)
                .add()
                ;

            header.actions.Should().Contain(a => a.title == title);
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