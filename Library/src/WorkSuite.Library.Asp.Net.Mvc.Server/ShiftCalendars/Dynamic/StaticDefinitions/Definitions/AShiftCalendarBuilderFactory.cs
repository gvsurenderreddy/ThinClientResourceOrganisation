namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions
{
    public interface AShiftCalendarBuilderFactory
    {
        BuildDynamicShiftCalendarFromStaticDefinition<S> create_builder<S>();
    }
}