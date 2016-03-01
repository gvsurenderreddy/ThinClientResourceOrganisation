namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration
{
    public interface ADateRangeBarBuilderFactory
    {
        BuildDynamicDateRangeBarFromStaticDefinition<S> create_builder<S>();
    }
}