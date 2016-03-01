using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Actions.Fields.Classes
{
    [TestClass]
    public class Action_class_can_be_defined_statically
    {
        [TestMethod]
        public void but_it_is_an_empty_string_if_not_defined()
        {
            actions_definition_builder
                .new_action<An_Action>()
                .add()
                ;

            var action = shift_calendar.actions.First();

            action.classes.Should().NotBeNull();
            action.classes.Should().BeEmpty();
        }

        [TestMethod]
        public void as_a_string()
        {
            var a_class = "A class";

            actions_definition_builder
                .new_action<An_Action>()
                .add_class(a_class)
                .add()
                ;

            var action = shift_calendar.actions.First();

            action.classes.Should().Contain(c => c == a_class);
        }

        [TestMethod]
        public void from_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            actions_definition_builder
                .new_action<An_Action>()
                .add_class(() => a_class)
                .add()
                ;

            var action = shift_calendar.actions.First();

            action.classes.Should().Contain(c => c == a_class);
        }

        [TestMethod]
        public void by_adding_multiple_classes()
        {
            var a_class = "A class";
            var another_class = DateTime.Now.Ticks.ToString();

            actions_definition_builder
                .new_action<An_Action>()
                .add_class(a_class)
                .add_class(() => another_class)
                .add()
                ;

            var action = shift_calendar.actions.First();

            action.classes.Should().Contain(c => c == a_class);
            action.classes.Should().Contain(c => c == another_class);
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