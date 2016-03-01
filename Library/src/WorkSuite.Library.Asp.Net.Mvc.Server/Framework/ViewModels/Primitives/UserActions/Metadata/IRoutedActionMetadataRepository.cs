using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Metadata {

    public interface IRoutedActionMetadataRepository<S,out M> where M : RoutedActionMetadata<S> {
        
        IEnumerable<M> metadata ( );
    }

}