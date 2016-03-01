using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration
{
    public class BuildFieldSetValidationResponsePolicyDefinitionsInAssembly
    {
        public void build(IDependencyResolver resolver)
        {
            metadata_configurations.Do(c => c.build(resolver));
        }

        public BuildFieldSetValidationResponsePolicyDefinitionsInAssembly(Assembly from_assembly)
        {
            assembly = Guard.IsNotNull(from_assembly, "from_assembly");
        }

        private IEnumerable<IFieldSetValidationResponsePolicyDefinitionBuilder> metadata_configurations
        {
            get
            {
                var catalog = new AssemblyCatalog(assembly);
                var container = new CompositionContainer(catalog);

                return container.GetExportedValues<IFieldSetValidationResponsePolicyDefinitionBuilder>();
            }
        }

        private readonly Assembly assembly;
    }
}
