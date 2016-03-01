using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static {

    /// <summary>
    /// This is a marker interface that identifies DetailsLists metadata builder. The metadata builders 
    /// create a DetailsList's metadata and put it into its DetailsList type’s metadata repository.  It is intended 
    /// that when an application is bootstrapping all the classes in the application assembly that 
    /// implement this interfaces will instantiated and their build method executed.    
    /// </summary>
    public interface IDetailsListMetadataBuilder {

        /// <summary>
        ///     Create the reports metadata and adds it to that reports metadata repository
        /// </summary>
        /// <param name="resolver">
        ///     The dependency resolver that the report metadata repository should be resolved from.
        /// </param>
        void build 
                ( IDependencyResolver resolver );
    }
}