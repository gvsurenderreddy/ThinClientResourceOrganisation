using System;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions
{
    /// <summary>
    ///     Allows you to add action definitions to a Shift Calendars Lister.
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the Shift Calendars Lister model
    /// </typeparam>
    public class DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S>
    {
        /// <summary>
        ///     Sets the title of the action that is created from this definition using the supplied value.
        /// </summary>
        /// <param name="the_value">
        ///     The value passed-in that the title of the action to be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> title(string the_value)
        {
            _definition.title = m => the_value;
            return this;
        }

        /// <summary>
        ///     Sets the title of the action that is created from this definition using the supplied value.
        /// </summary>
        /// <param name="the_dynamic_title_expression">
        ///     The expression generates from the model that the title of the action to be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> title(
            Func<S, string> the_dynamic_title_expression)
        {
            _definition.title = the_dynamic_title_expression;
            return this;
        }

        /// <summary>
        ///     Sets the name of the action that is created from this definition using the supplied value.
        ///     It is used by the javascript in the client to identify the event that it will trigger.
        /// </summary>
        /// <remarks>
        ///     This is internal as we do not want the name to be overriden it should come from the Action definition because
        /// we hook onto this in javascript.
        /// </remarks>
        /// <param name="the_value">
        ///     The value passed-in that the name of the action to be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        internal DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> name(string the_value)
        {
            _definition.name = m => the_value;
            return this;
        }
        
        /// <summary>
        ///     Adds a class to the collection of classes that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_value">
        ///     The value passed-in to be added to classes of the action
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> add_class(string the_value)
        {
            _definition.classes.Add(m => the_value);
            return this;
        }

        /// <summary>
        ///     Adds a class to the collection of classes that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_class_expression">
        ///     The expression generates from the model the class name to be added to classes of the action.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> add_class(
            Func<string> the_class_expression)
        {
            _definition.classes.Add(m => the_class_expression());
            return this;
        }

        /// <summary>
        ///     Adds a class to the collection of classes that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_dynamic_class_expression">
        ///     The expression generates from the model the class name to be added to classes of the action.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> add_class(
            Func<S, string> the_dynamic_class_expression)
        {
            _definition.classes.Add(the_dynamic_class_expression);
            return this;
        }

        /// <summary>
        ///     Adds the url that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_value">
        ///     The value passed-in to be the url that the action want to use.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> url(string the_value)
        {
            _definition.url = new UrlDefinition.StaticUrlDefinition
            {
                url_expression = () => the_value
            };
            return this;
        }

        /// <summary>
        ///     Adds the url that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_dynamic_url_expression">
        ///     The expression generates from the model to be the url that the action want to use.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> url(
            Func<S, string> the_dynamic_url_expression)
        {
            _definition.url = new UrlDefinition.DynamicUrlDefinition<S>
            {
                url_expression = the_dynamic_url_expression
            };
            return this;
        }

        /// <summary>
        ///     Add the name of the route and the route parameter factory that will be used to generate the
        ///     url that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_route_name">
        ///     The name of the route that url is going to be built from.
        /// </param>
        /// <param name="the_route_parameters_factory">
        ///     factory that generates the route parameters.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> url_from_route(string the_route_name,
                                                                                            Func<object> the_route_parameters_factory
                                                                                         )
        {
            _definition.url = new UrlDefinition.StaticRouteUrlDefinition
            {
                route_name = the_route_name,
                route_parameter_expression = the_route_parameters_factory
            };
            return this;
        }

        /// <summary>
        ///     Add the name of the route and the route parameter factory that will be used to generate the
        ///     url that will be applied to action created from this definition.
        /// </summary>
        /// <param name="the_dynamic_route_name_expression">
        ///     The expression that generates the route name.
        /// </param>
        /// <param name="the_dynamic_route_parameters_factory">
        ///     The expression that generates the route parameters.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> url_from_route(Func<S, string> the_dynamic_route_name_expression,
                                                                                            Func<S, object> the_dynamic_route_parameters_factory
                                                                                         )
        {
            _definition.url = new UrlDefinition.DynamicRouteUrlDefinition<S>
            {
                route_name_expression = the_dynamic_route_name_expression,
                route_parameter_expression = the_dynamic_route_parameters_factory
            };
            return this;
        }

        /// <summary>
        ///     Adds the action definition to Shift Calendars Lister definition.
        /// </summary>
        public void add()
        {
            _add_definition(_definition);
        }

        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder(Action<DynamicShiftCalendarsListerActionStaticDefinition<S>> the_add_definition_delegate)
        {
            _add_definition = Guard.IsNotNull(the_add_definition_delegate, "the_add_definition_delegate");

            _definition = new DynamicShiftCalendarsListerActionStaticDefinition<S>
            {
                title = m => string.Empty,
                name = m => string.Empty,
                classes = new Collection<Func<S, string>>()
            };
        }

        private readonly Action<DynamicShiftCalendarsListerActionStaticDefinition<S>> _add_definition;
        private readonly DynamicShiftCalendarsListerActionStaticDefinition<S> _definition;
    }
}