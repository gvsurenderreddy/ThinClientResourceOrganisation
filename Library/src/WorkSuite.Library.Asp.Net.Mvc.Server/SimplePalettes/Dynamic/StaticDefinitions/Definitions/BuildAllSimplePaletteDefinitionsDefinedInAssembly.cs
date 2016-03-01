using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Helper class that will identify all the <see cref="ISimplePaletteDefinitionsBuilder"/> that
    /// have been defined in an assembly and execute them.
    /// </summary>
    public class BuildAllSimplePaletteDefinitionsDefinedInAssembly
    {
        /// <summary>
        ///     Executes the build method of all the <see cref="ISimplePaletteDefinitionsBuilder"/> defined in
        /// the assembly
        /// </summary>
        /// <param name="resolver">
        ///     The dependency reolver that is passed as the argument when
        /// executing the build method of each of the <see cref="ISimplePaletteDefinitionsBuilder"/>
        /// </param>

        public void build
                        (IDependencyResolver resolver)
        {
            definitions_configurations.Do(c => c.build(resolver));
        }

        private IEnumerable<ISimplePaletteDefinitionsBuilder> definitions_configurations
        {
            get
            {
                var catalog = new AssemblyCatalog(_assembly);
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<ISimplePaletteDefinitionsBuilder>();
            }
        }

        public BuildAllSimplePaletteDefinitionsDefinedInAssembly
                    (Assembly from_assembly)
        {
            _assembly = Guard.IsNotNull(from_assembly, "from_assembly");
        }

        // assembly that the ISimplePaletteDefinitionsBuilder are loaded from
        private readonly Assembly _assembly;
    }
}