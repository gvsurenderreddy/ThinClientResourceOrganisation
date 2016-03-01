using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Helper class that will identify all the <see cref="IShiftCalendarsListerDefinitionsBuilder"/> that
    ///     have been defined in an assembly and execute them.
    /// </summary>
    public class BuildAllShiftCalendarsListerDefinitionsDefinedInAssembly
    {
        /// <summary>
        ///     Executes the build method of all the <see cref="IShiftCalendarsListerDefinitionsBuilder"/> defined in
        /// the assembly.
        /// </summary>
        /// <param name="the_resolver">
        ///     The dependency reolver that is passed as the argument when
        ///     executing the build method of each of the <see cref="IShiftCalendarsListerDefinitionsBuilder"/>
        /// </param>
        public void build(IDependencyResolver the_resolver)
        {
            definitions_configurations.Do(c => c.build(the_resolver));
        }

        private IEnumerable<IShiftCalendarsListerDefinitionsBuilder> definitions_configurations
        {
            get
            {
                var catalog = new AssemblyCatalog(_assembly);
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IShiftCalendarsListerDefinitionsBuilder>();
            }
        }

        public BuildAllShiftCalendarsListerDefinitionsDefinedInAssembly(Assembly the_assembly)
        {
            _assembly = Guard.IsNotNull(the_assembly, "the_assembly");
        }

        private readonly Assembly _assembly;
    }
}