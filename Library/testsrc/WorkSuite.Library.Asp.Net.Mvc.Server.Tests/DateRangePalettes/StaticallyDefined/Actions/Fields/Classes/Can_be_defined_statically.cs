using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Actions.Fields.Classes
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
                .add_class(m=>"a class")
                .add()
                ;

            palette.actions.First(a => a.title == title).classes.Should().Contain(c => c == "a class");
        }

        [TestMethod]
        public void can_add_as_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();
            var title = new AnAction().title;

            actions_definition_builder
                .new_action<AnAction>()
                .add_class(m => a_class)
                .add()
                ;

            palette.actions.First(a => a.title == title).classes.Should().Contain(c => c == a_class);
        }

        [TestMethod]
        public void can_add_multiple_classes()
        {
            var a_class = DateTime.Now.Ticks.ToString();
            var title = new AnAction().title;

            actions_definition_builder
                .new_action<AnAction>()
                .add_class(m=>"a class")
                .add_class(m => a_class)
                .add()
                ;

            palette.actions.First(a => a.title == title).classes.Should().Contain(c => c == "a class");
            palette.actions.First(a => a.title == title).classes.Should().Contain(c => c == a_class);
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicDateRangePaletteStaticDefinitionHelper<Helpers.AModel> { model = new Helpers.AModel() };

            model.a_range = WTS.WorkSuite.Library.DomainTypes.ShiftCalendarRange.Week;

            definition_builder
                .selected_start_date(DateTime.Now.AddDays(5).Date)
                .calendar_start_date(DateTime.Now.Date)
                .selected_range(m => m.a_range)
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