using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Actions.Fields.Title
{
    [TestClass]
    public class Action_title_can_be_defined_statically
    {
        [TestMethod]
        public void as_a_string()
        {
            var action_title = new An_Action().title + "some more title description";

            actions_definition_builder
                .new_action<An_Action>()
                .title(action_title)
                .add()
                ;
            var action = shift_calendar.actions.First();

            action.title.Should().Be(action_title);
        }

        [TestMethod]
        public void from_the_action_definition()
        {
            var action_definition = new An_Action();

            actions_definition_builder
                .new_action<An_Action>()
                .add();

            var action = shift_calendar.actions.First();

            action.title.Should().Be(action_definition.title);
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

        private DynamicShiftCalendarActionsStaticDefinitionBuilder<AModel> actions_definition_builder
        {
            get { return _helper.actions_definition_builder; }
        }

        private ShiftCalendar shift_calendar
        {
            get { return _helper.shift_calendar; }
        }

        [TestInitialize]
        public void before_each_test()
        {
            _helper = new DynamicShiftCalendarStaticDefinitionHelper<AModel>
            {
                model = new AModel()
                {
                    a_start_date = DateTime.Now.Date,
                    the_range_returned = ShiftCalendarRange.Week,
                }
            };

            //Start date and range returned are mandatory
            _helper.definition_builder.start_date(m => m.a_start_date);
            _helper.definition_builder.number_of_days_range(m => m.the_range_returned);
        }

        private DynamicShiftCalendarStaticDefinitionHelper<AModel> _helper;
    }
}