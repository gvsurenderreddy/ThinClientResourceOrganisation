using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Fields.Classes
{
    [TestClass]
    public class Class_can_be_defined
    {
        [TestMethod]
        public void from_the_property_of_the_model()
        {
            model.a_class = "A class";

            definition_builder
                .add_class(m => m.a_class)
                ;

            lister.classes.Should().Contain(model.a_class);
        }

        private AModel model
        {
            get { return _helper.model; }
        }

        private DynamicShiftCalendarsListerStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return _helper.definition_builder; }
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