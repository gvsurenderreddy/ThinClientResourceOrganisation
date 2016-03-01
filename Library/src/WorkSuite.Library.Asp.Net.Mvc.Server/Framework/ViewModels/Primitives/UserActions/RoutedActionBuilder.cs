using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions
{
    public abstract class RoutedActionBuilder<R, M, S>
        where R : IRoutedActionMetadataRepository<S, M>
        where M : RoutedActionMetadata<S>
    {
        protected RoutedActionBuilder
            (R the_repository
            , INamedRouteUrlBuilder the_route_builder)
        {
            Guard.IsNotNull(the_repository, "the_repository");
            Guard.IsNotNull(the_route_builder, "the_route_builder");

            repository = the_repository;
            route_builder = the_route_builder;
        }

        public IEnumerable<RoutedAction> build(S model)
        {
            return build
                (am => (am.decide_if_enabled == null) || am.decide_if_enabled(model)
                    , m => () => m.route_parameter_factory(model));
            //// to do: need to check the field level security
        }

        public IEnumerable<RoutedAction> build()
        {
            return build(am => true
                        , m => () => new { });
        }

        private IEnumerable<RoutedAction> build
            (Func<RoutedActionMetadata<S>, bool> decide_if_enabled
            , Func<RoutedActionMetadata<S>, Func<object>> route_parametert_factory)
        {
            // to do: need to check the field level security
            Guard.IsNotNull(decide_if_enabled, "decide_if_enabled");
            return repository
                    .metadata()
                    .Select(am => new RoutedAction
                    {
                        id = am.id,
                        title = am.title,
                        classes = am.classes,
                        is_enabled = decide_if_enabled(am),
                        url = create_url(route_parametert_factory, am),
                        name = am.name,
                    });
        }

        private string create_url(Func<RoutedActionMetadata<S>, Func<object>> route_parametert_factory, M am)
        {
            if (am.id != null)
            {
                return route_builder.build(new NamedRouteUrlObjectBuildDefinition
                {
                    route_name = am.id,
                    route_parameters_factory = route_parametert_factory(am)
                });
            }
            return "";
        }

        private readonly INamedRouteUrlBuilder route_builder;
        private readonly R repository;
    }
}