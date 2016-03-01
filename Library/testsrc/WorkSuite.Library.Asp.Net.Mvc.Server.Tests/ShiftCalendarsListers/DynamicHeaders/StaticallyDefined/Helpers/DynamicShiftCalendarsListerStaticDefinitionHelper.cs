using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Helpers;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendarsListers.DynamicHeaders.StaticallyDefined.Helpers
{
    public class DynamicShiftCalendarsListerStaticDefinitionHelper<S>
    {
        public DynamicShiftCalendarsListerStaticDefinitionHelper()
        {
            route_builder = new FakeRouteBuilder();

            var url_builder = new BuildUrlFromDefinition<S>(route_builder);
            var repository = new DynamicShiftCalendarsListerStaticDefinitionRepository<S>();

            definition_builder = new DynamicShiftCalendarsListerStaticDefinitionBuilder<S>(repository);
            actions_definition_builder = new DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<S>(repository);
            shift_calendar_builder = new DynamicShiftCalendarsListerStaticDefinitionBuilder<S>(repository);
            _builder = new BuildDynamicShiftCalendarsListerFromStaticDefinition<S>(repository, url_builder);
        }

        public FakeRouteBuilder route_builder { get; private set; }

        public S model { get; set; }

        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> definition_builder { get; private set; }

        public DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<S> actions_definition_builder
        {
            get;
            private set;
        }

        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> shift_calendar_builder { get; private set; }

        public ShiftCalendarsLister lister { get { return _builder.build(model); } }

        private readonly BuildDynamicShiftCalendarsListerFromStaticDefinition<S> _builder;
    }
}