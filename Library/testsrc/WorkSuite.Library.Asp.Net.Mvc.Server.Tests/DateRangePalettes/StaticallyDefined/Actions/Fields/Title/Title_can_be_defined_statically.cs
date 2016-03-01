﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Actions.Fields.Title
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

            palette.actions.Should().Contain(a => a.title == action_definition.title);
        }

        [TestMethod]
        public void as_static_text()
        {
            var action_definition_template = new AnAction();
            var title = action_definition_template.title + "aaaaa";

            actions_definition_builder
                .new_action<AnAction>()
                .title(a=>title)
                .add()
                ;

            palette.actions.Should().Contain(a => a.title == title);
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicDateRangePaletteStaticDefinitionHelper<Helpers.AModel> {model = new Helpers.AModel()};

            model.a_range = WTS.WorkSuite.Library.DomainTypes.ShiftCalendarRange.Week;

            definition_builder
                .selected_start_date(DateTime.Now.AddDays(5).Date)
                .calendar_start_date(DateTime.Now.Date)
                .selected_range(m=>m.a_range)
                ;
        }

        private DynamicDateRangePaletteStaticDefinitionHelper<Helpers.AModel> helper;

        private Helpers.AModel model
        {
            get { return helper.model; }
        }

        private DynamicDateRangePaletteActionsStaticDefinitionBuilder<Helpers.AModel> actions_definition_builder
        {
            get { return helper.actions_definition_builder; }
        }

        private DynamicDateRangePaletteStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }

        private DateRangePalette palette
        {
            get { return helper.date_range_palette; }
        }
    }
}