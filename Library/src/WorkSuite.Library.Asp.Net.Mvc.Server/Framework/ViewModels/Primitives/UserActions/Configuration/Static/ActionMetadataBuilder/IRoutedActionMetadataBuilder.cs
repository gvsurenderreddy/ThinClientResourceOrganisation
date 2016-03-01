using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder
{
    public interface IRoutedActionMetadataBuilder<S, R> where R : IRoutedActionMetadataBuilder<S, R>
    {
        R id(string value);

        /// <summary>
        ///     Sets the class which is used as a hook for styling this class of
        /// action
        /// </summary>
        /// <param name="value">
        ///     Name of the class to associate with actions built from this
        /// metadata
        /// </param>
        /// <returns>
        ///     The builder so that the mehtod can be used as part of the fluent interface.
        /// </returns>
        R action_class(string value);

        /// <summary>
        ///     Sets the class which is used as a hook for styling this class of
        /// action - whether it is a primary or a secondary action
        /// </summary>
        /// <returns>
        ///     The builder so that the mehtod can be used as part of the fluent interface.
        /// </returns>
        R call_to_action<A>() where A : CallToAction, new();

        /// <summary>
        ///     Sets the name which is used as a hook for the interaction (javascript) to know
        /// what event should be triggered when an action build from this metadata is triggered.
        /// </summary>
        /// <param name="value">
        ///     Name to associate with actions built from this metadata
        /// </param>
        /// <returns>
        ///     The builder so that the method can be used as part of the fluent interface.
        /// </returns>
        R action_name(string value);

        R title(string value);

        R route_parameter_factory(Func<S, object> value);

        R is_not_a_routed_action();

        /// <summary>
        /// Set the expression that identifies whether an action should
        /// be enabled when first displayed 
        /// </summary>
        /// <param name="func">
        ///  Expression that decides whether the action is enabled or not
        /// </param>
        /// <returns>
        ///  The builder so that this method can be used as part of the fluent
        /// interface
        /// </returns>
        R is_enabled(Func<S, bool> func);
    }
}