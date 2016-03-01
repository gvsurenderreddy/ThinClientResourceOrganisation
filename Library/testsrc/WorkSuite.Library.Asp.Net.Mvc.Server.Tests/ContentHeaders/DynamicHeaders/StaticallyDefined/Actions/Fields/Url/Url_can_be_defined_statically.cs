using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Actions.Fields.Url
{
    [TestClass]
    public class Url_can_be_defined_statically
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

        // done: as static text
        // to do: via a route name

        [TestMethod]
        public void as_static_text()
        {
            var action_definition = new AnAction();

            actions_definition_builder
                .new_action<AnAction>()
                .url("A Url")
                .add()
                ;

            header.actions.Should().Contain(a => a.url == "A Url");
        }

        [TestMethod]
        public void from_a_property_of_the_model_via_a_route()
        {
            helper.route_builder.routes.Add("A route id", "A route");

            actions_definition_builder
                .new_action<AnAction>()
                .url_from_route("A route id", () => new { })
                .add()
                ;

            header.actions.Should().Contain(a => a.url == "A route");
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