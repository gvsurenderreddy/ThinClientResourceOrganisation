using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Generic Implementation of the <see cref="IShiftCalendarsListerDefinitionsBuilder)"/> that uses
    ///     definitions builders to allow its's descendents to define the model definitions.
    /// </summary>
    /// <typeparam name="S">
    ///     Identifies the type of report that definitions is for. Reports are defined for
    ///     types, so when a specilised version of the generic report builder asks for
    ///     its report's metadata it will recieve the metadata that was defined by a descendent
    ///     of this class that had been specialised with the matching type.
    /// </typeparam>
    [InheritedExport(typeof(IShiftCalendarsListerDefinitionsBuilder))]
    public abstract class ShiftCalendarsListerDefinitionsBuilder<S>
                                    : IShiftCalendarsListerDefinitionsBuilder
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_definitions_builder = resolver.GetService<DynamicShiftCalendarsListerStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definitions_builder);

            var actions_definitions_builder =
                resolver.GetService<DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<S>>();
            build_action_definitions(actions_definitions_builder);
        }

        /// <summary>
        ///     Provides a descendent with the builder that should be used to create the
        ///     Shift Calendars Lister's model definitions.
        /// </summary>
        /// <param name="the_model_definitions_builder">
        ///     The builder is used to define/create the Shift Calendars Lister's model definitions.
        /// </param>
        protected abstract void build_model_definitions(DynamicShiftCalendarsListerStaticDefinitionBuilder<S> the_model_definitions_builder);

        /// <summary>
        ///     Provides a descendent with the builder that should be used to create the
        ///     Shift Calendars Lister's actions definitions.
        /// </summary>
        /// <param name="the_actions_definitions_builder">
        ///     The builder is used to define/create the Shift Calendars Lister's actions definitions.
        /// </param>
        protected abstract void build_action_definitions(
            DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<S> the_actions_definitions_builder);
    }
}