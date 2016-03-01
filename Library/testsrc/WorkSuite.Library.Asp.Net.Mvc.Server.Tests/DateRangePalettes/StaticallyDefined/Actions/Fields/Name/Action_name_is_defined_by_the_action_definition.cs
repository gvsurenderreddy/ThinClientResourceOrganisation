using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Actions.Fields.Name
{
    [TestClass]
    public class Action_name_is_defined_by_the_action_definition
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

        // done: from the a property of the model

        [TestMethod]
        public void from_the_action_definition() {
            var definition = new AnAction();

            model.a_name = "A name dsasdasda";

            actions_definition_builder
                .new_action<AnAction>()
                .add()
                ;

            header.actions.Should().Contain(a => a.name == definition.action_name);
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

        private DateRangePalette header
        {
            get { return helper.date_range_palette; }
        }
    }
}