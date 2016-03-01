using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    /// <summary>
    /// This is a marker interface that identifies report metadata builder. The metadata builders 
    /// create a report's metadata and put it into its report type’s metadata repository.  It is intended 
    /// that when an application is bootstrapping all the classes in the application assembly that 
    /// implement this interfaces will instantiated and their build method executed.    
    /// </summary>
    public interface IReportMetadataBuilder {
        
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