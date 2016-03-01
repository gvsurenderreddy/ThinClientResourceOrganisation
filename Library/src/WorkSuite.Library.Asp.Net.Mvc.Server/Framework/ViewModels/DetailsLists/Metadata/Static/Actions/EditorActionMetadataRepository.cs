using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration {

    public class EditorActionMetadataRepository<S> : IEditorActionMetadataRepository<S> {

        public IEnumerable<EditorActionMetadata<S>> metadata () {
            return repository;
        }

        public void Add ( EditorActionMetadata<S> action ) {
            repository.Add( action );
        }


        private readonly List<EditorActionMetadata<S>> repository = new List<EditorActionMetadata<S>>();
    }
}