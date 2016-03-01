using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    /// <summary>
    ///     Helper class that will identify all the <see cref="IReportMetadataBuilder"/> that 
    /// have been defined in an assembly and execute them.
    /// </summary>
    public class BuildReportMetadataDefinedInAssembly {

        /// <summary>
        ///     Executes the build method of all the <see cref="IReportMetadataBuilder"/> defined in
        /// the assembly
        /// </summary>
        /// <param name="resolver">
        ///     The dependency reolver that is passed as the argument when 
        /// executing the build method of each of the <see cref="IReportMetadataBuilder"/>
        /// </param>
        public void build 
                        ( IDependencyResolver  resolver ) {
            
            metadata_configurations.Do( c => c.build( resolver ));             
        }

        public BuildReportMetadataDefinedInAssembly
                    ( Assembly from_assembly ) {
            
            assembly = Guard.IsNotNull( from_assembly, "from_assembly" );
        }


        private IEnumerable<IReportMetadataBuilder> metadata_configurations {
            
            get {
                var catalog = new AssemblyCatalog( assembly );
                var container = new CompositionContainer( catalog );

                return container.GetExportedValues<IReportMetadataBuilder>();
            }

        }

        // assembly that the IReportMetadataBuilder are loaded from
        private readonly Assembly assembly;
    }

}