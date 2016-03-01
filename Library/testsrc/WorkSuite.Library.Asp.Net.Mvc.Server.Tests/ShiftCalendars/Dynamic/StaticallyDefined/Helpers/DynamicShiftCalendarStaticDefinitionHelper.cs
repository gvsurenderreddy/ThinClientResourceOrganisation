using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Helpers;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers
{
    public class DynamicShiftCalendarStaticDefinitionHelper<S>
    {
        public DynamicShiftCalendarStaticDefinitionHelper()
        {
            route_builder = new FakeRouteBuilder();
            var url_builder = new BuildUrlFromDefinition<S>(route_builder);

            var repository = new DynamicShiftCalendarStaticDefinitionRepository<S>();
            definition_builder = new DynamicShiftCalendarStaticDefinitionBuilder<S>(repository);
            actions_definition_builder = new DynamicShiftCalendarActionsStaticDefinitionBuilder<S>(repository);

            _builder = new BuildDynamicShiftCalendarFromStaticDefinition<S>(repository, url_builder);
        }

        public FakeRouteBuilder route_builder { get; private set; }

        public S model { get; set; }

        public DynamicShiftCalendarStaticDefinitionBuilder<S> definition_builder { get; private set; }

        public DynamicShiftCalendarActionsStaticDefinitionBuilder<S> actions_definition_builder { get; private set; }

        public ShiftCalendar shift_calendar { get { return _builder.build(model); } }

        private readonly BuildDynamicShiftCalendarFromStaticDefinition<S> _builder;
    }
}