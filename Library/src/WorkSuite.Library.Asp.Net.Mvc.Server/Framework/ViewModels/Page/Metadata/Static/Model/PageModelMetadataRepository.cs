using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model {

    /// <inheritdoc/>
    public class PageModelMetadataRepository
                    : IPageModelMetadataRepository {

        /// <inheritdoc/>
        public PageModelMetatdata metadata_for
                                    ( string page_id ) {

            if ( !repository.ContainsKey( page_id ) ) {
                repository.Add( page_id, new PageModelMetatdata {
                    title = string.Empty
                } );                
            }
            return repository[ page_id ];
        }

        // dictionary that stores the view field_metadata
        private readonly Dictionary<string,PageModelMetatdata> repository = new Dictionary<string,PageModelMetatdata>();
    }

}