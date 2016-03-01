namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions
{
    public interface ASimplePaletteBuilderFactory
    {
        BuildDynamicSimplePaletteFromStaticDefinition<S> create_builder<S>();
    }
}