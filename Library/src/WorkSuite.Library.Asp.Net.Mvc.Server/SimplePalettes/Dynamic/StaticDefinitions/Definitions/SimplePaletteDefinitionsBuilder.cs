using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Generic Implementation of the <see cref="ISimplePaletteDefinitionsBuilder)"/> that uses
    /// definitions builders to allow its's descendents to define the model definitions.
    /// </summary>
    /// <typeparam name="S">
    ///     Identifies the type of report that definitions is for. Reports are defined for
    /// types, so when a specilised version of the generic report builder asks for
    /// its report's metadata it will recieve the metadata that was defined by a descendent
    /// of this class that had been specialised with the matching type.
    /// </typeparam>
    [InheritedExport(typeof(ISimplePaletteDefinitionsBuilder))]
    public abstract class SimplePaletteDefinitionsBuilder<S>
                                : ISimplePaletteDefinitionsBuilder
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_definitions_builder = resolver.GetService<DynamicSimplePaletteStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definitions_builder);

            var actions_definitions_builder = resolver.GetService<DynamicSimplePaletteActionsStaticDefintionBuilder<S>>();
            build_action_definitions(actions_definitions_builder);
        }

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// simple palette's model definitions.
        /// </summary>
        /// <param name="model_definitions_builder">
        ///     the builder is used to define/create the simple palettes's model definitions
        /// </param>
        protected abstract void build_model_definitions
                                    (DynamicSimplePaletteStaticDefinitionBuilder<S> model_definitions_builder);

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// simple palette's actions definitions.
        /// </summary>
        /// <param name="actions_definitions_builder">
        ///     the builder is used to define/create the simple palette's actions definitions.
        /// </param>
        protected abstract void build_action_definitions
                                    (DynamicSimplePaletteActionsStaticDefintionBuilder<S> actions_definitions_builder);
    }
}