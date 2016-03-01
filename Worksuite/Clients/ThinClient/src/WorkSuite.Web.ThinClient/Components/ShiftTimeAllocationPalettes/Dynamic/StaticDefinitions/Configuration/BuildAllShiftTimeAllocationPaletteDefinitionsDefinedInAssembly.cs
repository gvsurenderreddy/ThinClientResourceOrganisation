using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration
{
    public class BuildAllShiftTimeAllocationPaletteDefinitionsDefinedInAssembly
    {
        public void build
                        (IDependencyResolver resolver)
        {
            definitions_configurations.Do(c => c.build(resolver));
        }

        private IEnumerable<IShiftTimeAllocationPaletteDefinitionsBuilder> definitions_configurations
        {
            get
            {
                var catalog = new AssemblyCatalog(_assembly);
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IShiftTimeAllocationPaletteDefinitionsBuilder>();
            }
        }

        public BuildAllShiftTimeAllocationPaletteDefinitionsDefinedInAssembly
                    (Assembly from_assembly)
        {
            _assembly = Guard.IsNotNull(from_assembly, "from_assembly");
        }

        // assembly that the IShiftTimeAllocationPaletteDefinitionsBuilder are loaded from
        private readonly Assembly _assembly;
    }
}