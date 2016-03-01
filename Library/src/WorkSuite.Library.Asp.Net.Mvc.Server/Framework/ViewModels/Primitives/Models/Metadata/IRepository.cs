namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata {

    public interface IRepository<S, out R> where R : IModelMetadata<S> {
        
        R metadata_for ( );
 
    }
}