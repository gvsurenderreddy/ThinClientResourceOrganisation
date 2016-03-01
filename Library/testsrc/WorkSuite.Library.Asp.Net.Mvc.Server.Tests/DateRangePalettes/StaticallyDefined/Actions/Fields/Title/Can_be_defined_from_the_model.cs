using System;
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
    public class Title_can_be_defined_from_the_model
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
        public void from_the_a_property_of_the_model()
        {
            model.a_title = "A title dsasdasda";

            actions_definition_builder
                .new_action<AnAction>()
                .title(m => m.a_title)
                .add()
                ;

            palette.actions.Should().Contain(a => a.title == model.a_title);
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