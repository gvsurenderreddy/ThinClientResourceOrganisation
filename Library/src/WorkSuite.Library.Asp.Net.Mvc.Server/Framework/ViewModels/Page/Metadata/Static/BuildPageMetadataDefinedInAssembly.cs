using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static {

    // Improve: This is just copied from the BuildReportMetadataDefinedInAssembly it could be made generic (WPM).

    /// <summary>
    ///     Helper class that will identify all the <see cref="IPageMetadataBuilder"/> that 
    /// have been defined in an assembly and execute them.
    /// </summary>
    public class BuildPageMetadataDefinedInAssembly {
    
        /// <summary>
        ///     Executes the build method of all the <see cref="IPageMetadataBuilder"/> defined in
        /// an assembly
        /// </summary>
        /// <param name="resolver">
        ///     The dependency reolver that is passed as the argument when 
        /// executing the build method of each of the <see cref="IPageMetadataBuilder"/>
        /// </param>
        public void build 
                        ( IDependencyResolver  resolver ) {
            
            metadata_configurations.Do( c => c.build( resolver ));             
        }

        public BuildPageMetadataDefinedInAssembly
                    ( Assembly from_assembly ) {
            
            assembly = Guard.IsNotNull( from_assembly, "from_assembly" );
        }


        private IEnumerable<IPageMetadataBuilder> metadata_configurations {
            
            get {
                var catalog = new AssemblyCatalog( assembly );
                var container = new CompositionContainer( catalog );

                return container.GetExportedValues<IPageMetadataBuilder>();
            }
        }

        // assembly that the IReportMetadataBuilder are loaded from
        private readonly Assembly assembly;     
    }
}