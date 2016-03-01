namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists
{
    public interface ADetailsListBuilderFactory
    {
        DetailsListBuilder<S> create_builder<S>();  
    }
}