using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {
    
    public class BuildEditorMetadataDefinedInAssembly {

        /// <summary>
        ///     Executes the build method of all the <see cref="IEditorMetadataBuilder"/> defined in
        /// the assembly
        /// </summary>
        /// <param name="resolver">
        ///     The dependency reolver that is passed as the argument when 
        /// executing the build method of each of the <see cref="IEditorMetadataBuilder"/>
        /// </param>
        public void build
                        ( IDependencyResolver resolver ) {

            foreach ( var configuration in metadata_configurations ) {
                configuration.build( resolver );
            }
        }


        public BuildEditorMetadataDefinedInAssembly ( Assembly from_assembly ) {
            Guard.IsNotNull( from_assembly, "from_assembly" );

            assembly = from_assembly;
        }



        private IEnumerable<IEditorMetadataBuilder> metadata_configurations {

            get {
                var catalog = new AssemblyCatalog( assembly );
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IEditorMetadataBuilder>();
            }
        }

        // assembly that the configurations are loaded from
        private readonly Assembly assembly;
    }
}