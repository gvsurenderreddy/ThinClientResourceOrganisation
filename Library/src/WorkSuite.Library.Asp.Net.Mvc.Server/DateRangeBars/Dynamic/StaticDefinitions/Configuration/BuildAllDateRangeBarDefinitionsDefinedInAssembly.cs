using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration
{
    public class BuildAllDateRangeBarDefinitionsDefinedInAssembly
    {
        public void build
                        (IDependencyResolver resolver)
        {
            definitions_configurations.Do(c => c.build(resolver));
        }

        private IEnumerable<IDateRangeBarDefinitionsBuilder> definitions_configurations
        {
            get
            {
                var catalog = new AssemblyCatalog(_assembly);
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IDateRangeBarDefinitionsBuilder>();
            }
        }

        public BuildAllDateRangeBarDefinitionsDefinedInAssembly
                    (Assembly from_assembly)
        {
            _assembly = Guard.IsNotNull(from_assembly, "from_assembly");
        }

        // assembly that the IDateRangeBarDefinitionsBuilder are loaded from
        private readonly Assembly _assembly;
    }
}