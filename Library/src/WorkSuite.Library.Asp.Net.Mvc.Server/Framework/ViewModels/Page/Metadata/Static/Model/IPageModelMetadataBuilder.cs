namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model {

    /// <summary>
    ///     Provides a fluent interface for building the model metadata for 
    /// a page.  This is intended to abstract how we implement the metadata 
    /// from the client that is only interested in setting the model properties.
    /// </summary>
    /// <remarks>
    ///     This is a slightly different implementation to the other metadata 
    /// builders because we identify a page via an id rather than from a specific
    /// type.
    /// </remarks>
    public interface IPageModelMetadataBuilder {

        /// <summary>
        ///     Sets the title of the page
        /// </summary>
        /// <param name="value">
        ///     Value that you want the page title to be.
        /// </param>
        /// <returns>
        ///     <see cref="IPageModelMetadataBuilder"/> so that you can use the builder
        /// as a fluent interface.
        /// </returns>
        IPageModelMetadataBuilder title
                                    ( string value );
    }
}
