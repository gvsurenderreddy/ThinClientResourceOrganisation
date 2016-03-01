using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Actions.Fields.Classes
{
    [TestClass]
    public class Can_be_defined_statically
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

        [TestMethod]
        public void can_add_as_a_string()
        {
            var title = new AnAction().title;

            actions_definition_builder
                .new_action<AnAction>()
                .add_class("a class")
                .add()
                ;

            header.actions.First(a => a.title == title).classes.Should().Contain(c => c == "a class");
        }

        [TestMethod]
        public void can_add_as_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();
            var title = new AnAction().title;

            actions_definition_builder
                .new_action<AnAction>()
                .add_class(() => a_class)
                .add()
                ;

            header.actions.First(a => a.title == title).classes.Should().Contain(c => c == a_class);
        }

        [TestMethod]
        public void can_add_multiple_classes()
        {
            var a_class = DateTime.Now.Ticks.ToString();
            var title = new AnAction().title;

            actions_definition_builder
                .new_action<AnAction>()
                .add_class("a class")
                .add_class(() => a_class)
                .add()
                ;

            header.actions.First(a => a.title == title).classes.Should().Contain(c => c == "a class");
            header.actions.First(a => a.title == title).classes.Should().Contain(c => c == a_class);
        }

        [TestMethod]
        public void is_an_empty_collection_if_none_specified()
        {
            var title = new AnAction().title;

            actions_definition_builder
                .new_action<AnAction>()
                .add()
                ;

            header.actions.First(a => a.title == title).classes.Should().BeEmpty();
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