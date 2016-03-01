using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions
{
    /// <summary>
    ///     Builder that will create a dynamic content headr from statically defined definition
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the dynamic content header is built from
    /// </typeparam>
    public class BuildDynamicContentHeaderFromStaticDefinition<S>
    {
        /// <summary>
        ///     Builds the content header for the model.
        /// </summary>
        /// <param name="model">
        ///     The model that is the source of the dynamic data.
        /// </param>
        /// <returns>
        ///     A content header that has been built from the model.
        /// </returns>
        public ContentHeader build
                                (S model)
        {
            return new ContentHeader
            {
                title = definition.title.value_or_default(string.Empty)(model),
                classes = definition.classes.Select(ce => ce(model)).ToList(),
                actions = actions.Select(action_definition => create_action(action_definition, model)).ToList(),
            };
        }

        public BuildDynamicContentHeaderFromStaticDefinition
                (DynamicContentHeaderStaticDefinitionRepository<S> the_repository
                , BuildUrlFromDefinition<S> the_url_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository ");
            url_builder = Guard.IsNotNull(the_url_builder, "the_url_builder ");
        }

        private DynamicContentHeaderStaticDefinition<S> definition
        {
            get { return repository.definition; }
        }

        private IEnumerable<DynamicContentHeaderActionStaticDefintion<S>> actions
        {
            get { return repository.actions; }
        }

        // creates an content header action from an action definition
        private ContentHeaderAction create_action
                                        (DynamicContentHeaderActionStaticDefintion<S> action_definition
                                        , S model)
        {
            return new ContentHeaderAction
            {
                title = action_definition.title(model),
                name = action_definition.name(model),
                url = url_builder.build(action_definition.url, model),
                classes = action_definition.classes.Select(class_definition => class_definition(model)).ToList(),
            };
        }

        private readonly DynamicContentHeaderStaticDefinitionRepository<S> repository;
        private readonly BuildUrlFromDefinition<S> url_builder;
    }
}