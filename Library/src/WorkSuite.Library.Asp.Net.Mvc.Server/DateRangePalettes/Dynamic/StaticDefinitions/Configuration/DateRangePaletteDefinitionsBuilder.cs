using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration
{
    [InheritedExport(typeof(IDateRangePaletteDefinitionsBuilder))]
    public abstract class DateRangePaletteDefinitionsBuilder<S> : IDateRangePaletteDefinitionsBuilder
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_definitions_builder = resolver.GetService<DynamicDateRangePaletteStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definitions_builder);

            var actions_definitions_builder = resolver.GetService<DynamicDateRangePaletteActionsStaticDefinitionBuilder<S>>();
            build_actions_definitions(actions_definitions_builder);

        }

        protected abstract void build_model_definitions(DynamicDateRangePaletteStaticDefinitionBuilder<S> model_definitions_builder);

        protected abstract void build_actions_definitions(DynamicDateRangePaletteActionsStaticDefinitionBuilder<S> actions_definitions_builder);
    }
}