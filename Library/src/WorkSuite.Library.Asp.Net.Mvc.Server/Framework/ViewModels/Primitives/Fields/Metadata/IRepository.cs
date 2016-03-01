using System.Reflection;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata {
    
    public interface IRepository<M,S> where M : FieldMetadata<S> {

        M metadata_for ( PropertyInfo property );
    }
}