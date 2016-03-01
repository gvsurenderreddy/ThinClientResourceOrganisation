using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Actions.Fields.Url
{
    [TestClass]
    public class Action_url_can_be_defined
    {
        [TestMethod]
        public void from_a_property_of_the_model_via_static_string()
        {
            model.a_url = "A url";

            actions_definition_builder
                .new_action<An_Action>()
                .url(m => m.a_url)
                .add()
                ;

            var action = lister.actions.First();

            action.url.Should().Be(model.a_url);
        }

        [TestMethod]
        public void from_a_property_of_the_model_via_a_route()
        {
            model.a_route_id = "A route id";
            var a_route = "A route";
            _helper.route_builder.routes.Add(model.a_route_id, a_route);

            actions_definition_builder
                .new_action<An_Action>()
                .url_from_route(m => m.a_route_id, m => new { })
                .add()
                ;

            var action = lister.actions.First();

            action.url.Should().Be(a_route);
        }

        private class An_Action
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
                get { return "Action name"; }
            }
        }

        private AModel model
        {
            get { return _helper.model; }
        }

        private DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<AModel> actions_definition_builder
        {
            get { return _helper.actions_definition_builder; }
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