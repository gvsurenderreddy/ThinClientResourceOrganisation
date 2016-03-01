using System.ComponentModel.Composition;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration
{
    [InheritedExport(typeof(IDateRangeBarDefinitionsBuilder))]
    public abstract class DateRangeBarDefinitionsBuilder<S> : IDateRangeBarDefinitionsBuilder
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_definitions_builder = resolver.GetService<DynamicDateRangeBarStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definitions_builder);
        }

        protected abstract void build_model_definitions(DynamicDateRangeBarStaticDefinitionBuilder<S> model_definitions_builder);

    }
}