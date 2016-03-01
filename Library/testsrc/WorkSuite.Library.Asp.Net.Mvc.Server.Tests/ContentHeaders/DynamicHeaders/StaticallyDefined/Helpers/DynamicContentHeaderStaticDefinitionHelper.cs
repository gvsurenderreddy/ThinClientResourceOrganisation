using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Helpers;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ContentHeaders.DynamicHeaders.StaticallyDefined.Helpers {

    public class DynamicContentHeaderStaticDefinitionHelper<S> {

        public FakeRouteBuilder route_builder { get; private set; }

        public S model { get; set; }

        public DynamicContentHeaderStaticDefinitionBuilder<S> definition_builder { get; private set; }

        public DynamicContentHeaderActionsStaticDefintionBuilder<S> actions_definition_builder { get; private set; }
 
        public ContentHeader header {
            get { return header_builder.build( model ); }
        }

        public DynamicContentHeaderStaticDefinitionHelper() {
            route_builder = new FakeRouteBuilder();

            var url_builder = new BuildUrlFromDefinition<S>( route_builder );
            var repository = new DynamicContentHeaderStaticDefinitionRepository<S>();

            definition_builder = new DynamicContentHeaderStaticDefinitionBuilder<S>( repository );
            actions_definition_builder = new DynamicContentHeaderActionsStaticDefintionBuilder<S>(repository);
            header_builder = new BuildDynamicContentHeaderFromStaticDefinition<S>(repository, url_builder);
        }

        private readonly BuildDynamicContentHeaderFromStaticDefinition<S> header_builder;
    }
}