using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    /// <summary>
    /// This is a marker interface that identifies an editor metadata builder. The metadata builders 
    /// create an editor's metadata and put it into its editor type’s metadata repository.  It is intended 
    /// that when an application is bootstrapping all the classes in the application assembly that implement 
    /// this interfaces will instantiated and their build method executed.    
    /// </summary>
    public interface IEditorMetadataBuilder {

        /// <summary>
        ///     Create the editors metadata and adds it to that editors metadata repository
        /// </summary>
        /// <param name="resolver">
        ///     The dependency resolver that the editor metadata repository should be resolved from.
        /// </param>
        void build 
                ( IDependencyResolver resolver );
    }
}