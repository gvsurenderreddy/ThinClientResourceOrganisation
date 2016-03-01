// Note - I have put this here so that we can identify where in the framework 
//        starts.
//
//        There may be better ways of doing this as I am quite new to using 
//        the namespaces in this way 

using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;
using Primitives = WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata {

    public interface IEditorFieldMetadataRepository<S> : Primitives.Fields.Metadata.IRepository<EditorFieldMetadata<S>,S> { }


}