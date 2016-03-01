namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model {

    /// <summary>
    ///     Creates a Page model metadata builder for a page.
    /// </summary>
    public interface IPageModelMetadataBuilderFactory {

        IPageModelMetadataBuilder create 
                                    ( string page_id );
    }
}