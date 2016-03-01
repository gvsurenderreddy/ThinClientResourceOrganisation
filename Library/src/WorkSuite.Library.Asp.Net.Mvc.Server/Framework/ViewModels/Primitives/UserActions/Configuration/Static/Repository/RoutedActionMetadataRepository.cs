using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.Repository {

    public class RoutedActionMetadataRepository<S,R> : IRoutedActionMetadataRepository<S,R> where R : RoutedActionMetadata<S> {

        public IEnumerable<R> metadata () {
            return repository;
        }

        public void Add ( R action ) {
            repository.Add( action );
        }


        private readonly List<R> repository = new List<R>();
    }
}