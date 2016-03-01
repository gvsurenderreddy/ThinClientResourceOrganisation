namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration
{
    public interface ADateRangePaletteBuilderFactory
    {
        BuildDynamicDateRangePaletteFromStaticDefinition<S> create_builder<S>();
    }
}