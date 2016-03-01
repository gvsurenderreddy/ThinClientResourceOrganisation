using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static {
    
    public class BuildDetailsListMetadataDefinedInAssembly {


        /// <summary>
        ///     Executes the build method of all the <see cref="IDetailsListMetadataBuilder"/> defined in
        /// the assembly
        /// </summary>
        /// <param name="resolver">
        ///     The dependency reolver that is passed as the argument when 
        /// executing the build method of each of the <see cref="IDetailsListMetadataBuilder"/>
        /// </param>
        public void build
                        ( IDependencyResolver resolver ) {

            foreach ( var configuration in metadata_configurations ) {
                configuration.build(resolver);
            }
        }

        
        
        public BuildDetailsListMetadataDefinedInAssembly 
                ( Assembly from_assembly ) {
            
            assembly = Guard.IsNotNull( from_assembly, "from_assembly" );
        }


        private IEnumerable<IDetailsListMetadataBuilder> metadata_configurations {

            get {
                var catalog = new AssemblyCatalog( assembly );
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IDetailsListMetadataBuilder>();
            }
        }

        // assembly that the configurations are loaded from
        private readonly Assembly assembly;
    }
}