using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Actions.Fields.Title
{
    [TestClass]
    public class Action_title_can_be_defined
    {
        [TestMethod]
        public void from_the_property_of_the_model()
        {
            model.a_title = "A title";

            actions_definition_builder
                .new_action<An_Action>()
                .title(m => m.a_title)
                .add()
                ;

            var action = lister.actions.First();

            action.title.Should().Be(model.a_title);
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