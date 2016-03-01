using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Actions.Fields.Url
{
    [TestClass]
    public class Action_url_can_be_defined_statically
    {
        [TestMethod]
        public void as_a__static_string()
        {
            var a_url = "A url";

            actions_definition_builder
                .new_action<An_Action>()
                .url(a_url)
                .add()
                ;

            var action = shift_calendar.actions.First();

            action.url.Should().Be(a_url);
        }

        [TestMethod]
        public void from_a_property_of_the_model_via_a_route()
        {
            var a_route_id = "A route id";
            var a_route = "A route";

            _helper.route_builder.routes.Add(a_route_id, a_route);

            actions_definition_builder
                .new_action<An_Action>()
                .url_from_route(a_route_id, () => new { })
                .add()
                ;

            var action = shift_calendar.actions.First();

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

        private DynamicShiftCalendarActionsStaticDefinitionBuilder<AModel> actions_definition_builder
        {
            get { return _helper.actions_definition_builder; }
        }

        private DynamicShiftCalendarStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return _helper.definition_builder; }
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