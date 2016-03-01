namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    public interface AShiftCalendarsListerBuilderFactory
    {
        BuildDynamicShiftCalendarsListerFromStaticDefinition<S> create_builder<S>();
    }
}