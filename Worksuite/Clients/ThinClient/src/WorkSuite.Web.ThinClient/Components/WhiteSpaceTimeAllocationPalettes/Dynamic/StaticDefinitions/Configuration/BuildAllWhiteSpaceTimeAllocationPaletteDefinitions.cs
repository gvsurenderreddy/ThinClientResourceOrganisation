using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration
{
    public class BuildAllWhiteSpaceTimeAllocationPaletteDefinitionsDefinedInAssembly
    {
        public void build
                        (IDependencyResolver resolver)
        {
            definitions_configurations.Do(c => c.build(resolver));
        }

        private IEnumerable<IWhiteSpaceTimeAllocationPaletteDefinitionsBuilder> definitions_configurations
        {
            get
            {
                var catalog = new AssemblyCatalog(_assembly);
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IWhiteSpaceTimeAllocationPaletteDefinitionsBuilder>();
            }
        }

        public BuildAllWhiteSpaceTimeAllocationPaletteDefinitionsDefinedInAssembly
                    (Assembly from_assembly)
        {
            _assembly = Guard.IsNotNull(from_assembly, "from_assembly");
        }

        // assembly that the IWhiteSpaceTimeAllocationPaletteDefinitionsBuilder are loaded from
        private readonly Assembly _assembly;
    }
}