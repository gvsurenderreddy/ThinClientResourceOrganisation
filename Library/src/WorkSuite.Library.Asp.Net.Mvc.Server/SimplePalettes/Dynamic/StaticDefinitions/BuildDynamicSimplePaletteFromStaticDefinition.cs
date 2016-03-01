using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions
{
    /// <summary>
    ///     Builder that will create a dynamic simple palette from statically defined definition
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the dynamic simple palette is built from
    /// </typeparam>
    public class BuildDynamicSimplePaletteFromStaticDefinition<S>
    {
        /// <summary>
        ///     Builds the simple palette for the model.
        /// </summary>
        /// <param name="model">
        ///     The model that is the source of the dynamic data.
        /// </param>
        /// <returns>
        ///     A simple palette that has been built from the model.
        /// </returns>
        public SimplePalette build
                                (S model)
        {
            return new SimplePalette
            {
                title = definition.title.value_or_default(string.Empty)(model),
                classes = definition.classes.Select(ce => ce(model)).ToList(),
                actions = actions.Select(action_definition => create_action(action_definition, model)).ToList(),
                description = definition.description.value_or_default(string.Empty)(model),
            };
        }

        public BuildDynamicSimplePaletteFromStaticDefinition
                (DynamicSimplePaletteStaticDefinitionRepository<S> the_repository
                , BuildUrlFromDefinition<S> the_url_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository ");
            url_builder = Guard.IsNotNull(the_url_builder, "the_url_builder ");
        }

        private DynamicSimplePaletteStaticDefinition<S> definition
        {
            get { return repository.definition; }
        }

        private IEnumerable<DynamicSimplePaletteActionStaticDefintion<S>> actions
        {
            get { return repository.actions; }
        }

        // creates an simple palette action from an action definition
        private SimplePaletteAction create_action
                                        (DynamicSimplePaletteActionStaticDefintion<S> action_definition
                                        , S model)
        {
            return new SimplePaletteAction
            {
                title = action_definition.title(model),
                name = action_definition.name(model),
                url = url_builder.build(action_definition.url, model),
                classes = action_definition.classes.Select(class_definition => class_definition(model)).ToList(),
                 component_context = action_definition.component_context(model)
            };
        }

        private readonly DynamicSimplePaletteStaticDefinitionRepository<S> repository;
        private readonly BuildUrlFromDefinition<S> url_builder;
    }
}