using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder
{
    public abstract class RoutedActionMetadataBuilder<S, R, M> : IRoutedActionMetadataBuilder<S, R>
        where R : IRoutedActionMetadataBuilder<S, R>
        where M : RoutedActionMetadata<S>, new()
    {
        public R id(string value)
        {
            return set_metatadata_value(() => metadata.id = value);
        }

        public R action_class(string value)
        {
            //return set_metatadata_value(() => metadata.action_class = value);
            metadata.classes.Add(value);

            return builder;
        }

        public R action_name(string value)
        {
            return set_metatadata_value(() => metadata.name = value);
        }

        public R title(string value)
        {
            return set_metatadata_value(() => metadata.title = value);
        }

        public R route_parameter_factory(Func<S, object> value)
        {
            return set_metatadata_value(() => metadata.route_parameter_factory = value);
        }

        public R is_enabled(Func<S, bool> func)
        {
           return set_metatadata_value(() => metadata.decide_if_enabled = func);
        }

        public R is_not_a_routed_action()
        {
            return set_metatadata_value(() => metadata.id = null);
        }

        public R call_to_action<A>()
                    where A : CallToAction, new()
        {
            var call_to_action = new A();

            //return set_metatadata_value(() => metadata.call_to_action = call_to_action);
            metadata.classes.Add(call_to_action.ToString());

            return builder;
        }

        protected RoutedActionMetadataBuilder(Action<M> add_to_repository)
        {
            Guard.IsNotNull(add_to_repository, "add_to_repository");

            metadata = new M
            {
                classes = new List<string>(),
                route_parameter_factory = m => new { }, // default to a no parameter factory
            };

            add_to_repository(metadata);
        }

        protected M metadata { get; private set; }

        protected abstract R builder { get; }

        protected R set_metatadata_value(Action set_value)
        {
            Guard.IsNotNull(metadata, "metadata");
            Guard.IsNotNull(builder, "builder");

            set_value();

            return builder;
        }
    }
}