using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Generic Implementation of the <see cref="IShiftCalendarDefinitionsBuilder)"/> that uses
    ///     definitions builders to allow its's descendents to define the model definitions.
    /// </summary>
    /// <typeparam name="S">
    ///     Identifies the type of report that definitions is for. Reports are defined for
    ///     types, so when a specilised version of the generic report builder asks for
    ///     its report's metadata it will recieve the metadata that was defined by a descendent
    ///     of this class that had been specialised with the matching type.
    /// </typeparam>
    [InheritedExport(typeof(IShiftCalendarDefinitionsBuilder))]
    public abstract class ShiftCalendarDefinitionsBuilder<S>
                                    : IShiftCalendarDefinitionsBuilder
    {
        public void build(IDependencyResolver the_resolver)
        {
            Guard.IsNotNull(the_resolver, "the_resolver");

            var model_definition_builder = the_resolver.GetService<DynamicShiftCalendarStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definition_builder);

            var actions_definitions_builder =
                the_resolver.GetService<DynamicShiftCalendarActionsStaticDefinitionBuilder<S>>();
            build_actions_definitions(actions_definitions_builder);
        }

        /// <summary>
        ///     Provides a descendent with the builder that should be used to create the
        ///     Shift Calendar's model definitions.
        /// </summary>
        /// <param name="the_model_definitions_builder">
        ///     The builder is used to define/create the Shift Calendar's model definitions.
        /// </param>
        protected abstract void build_model_definitions(DynamicShiftCalendarStaticDefinitionBuilder<S> the_model_definition_builder);

        /// <summary>
        ///     Provides a descendent with the builder that should be used to create the
        ///     Shift Calendar's actions definitions.
        /// </summary>
        /// <param name="the_actions_definitions_builder">
        ///     The builder is used to define/create the Shift Calendar's actions definitions.
        /// </param>
        protected abstract void build_actions_definitions(DynamicShiftCalendarActionsStaticDefinitionBuilder<S> actions_definitions_builder);
    }
}