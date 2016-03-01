namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions
{
    public interface AContentHeaderBuilderFactory
    {
        BuildDynamicContentHeaderFromStaticDefinition<S> create_builder<S>();
    }
}