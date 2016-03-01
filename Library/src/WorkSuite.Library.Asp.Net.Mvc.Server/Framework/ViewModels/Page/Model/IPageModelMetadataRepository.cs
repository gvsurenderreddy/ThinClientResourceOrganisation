namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model {

    /// <summary>
    ///     Repository that stores view field_metadata. e.g. view names
    /// </summary>
    public interface IPageModelMetadataRepository {

        /// <summary>
        ///     Gets the field_metadata for a specific page. If the metadata for 
        /// the page does not already exist then it is created.
        /// </summary>
        /// <param name="page_id">
        ///     Id of the page that the metadata is for.
        /// </param>
        /// <returns>
        ///     meta-data for the page.
        /// </returns>        
        PageModelMetatdata metadata_for 
                            ( string page_id ); 

    }

}