using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Allows a Dynamic Shift Calendars Lister static definition to be built.
    /// </summary>
    /// <typeparam name="S">
    ///     The model that the dynamic Shift Calendars Lister is built from.
    /// </typeparam>
    public class DynamicShiftCalendarsListerStaticDefinitionBuilder<S>
    {
        /// <summary>
        ///     Sets the title to be the supplied title for all Shift Calendars Lister
        /// </summary>
        /// <param name="the_value">
        ///     The value that the title should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> title(string the_value)
        {
            definition.title = m => the_value;
            return this;
        }

        /// <summary>
        ///     Sets the title to be the supplied title for all Shift Calendars Lister
        /// </summary>
        /// <param name="the_title_expression">
        ///     The expression that generates a value that the title should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> title(Func<string> the_title_expression)
        {
            definition.title = m => the_title_expression();
            return this;
        }

        /// <summary>
        ///     Sets the title to be the supplied title for all Shift Calendars Lister
        /// </summary>
        /// <param name="the_dynamic_title_expression">
        ///     The expression that generates a value from the model that the title should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> title(Func<S, string> the_dynamic_title_expression)
        {
            definition.title = the_dynamic_title_expression;
            return this;
        }

        /// <summary>
        ///     Adds a class to the Shift Calendars Lister.
        /// </summary>
        /// <param name="the_value">
        ///     The class that will be added to the Shift Calendars Lister.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> add_class(string the_value)
        {
            definition.classes.Add(m => the_value);
            return this;
        }

        /// <summary>
        ///     Adds a class to the Shift Calendars Lister.
        /// </summary>
        /// <param name="the_class_expression">
        ///     The expression that generates a class that will be added to the Shift Calendars Lister.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> add_class(Func<string> the_class_expression)
        {
            definition.classes.Add(m => the_class_expression());
            return this;
        }

        /// <summary>
        ///     Adds a class to the Shift Calendars Lister.
        /// </summary>
        /// <param name="the_dynamic_class_expression">
        ///     The expression that generates a class from the model that will be added to the Shift Calendars Lister.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> add_class(
            Func<S, string> the_dynamic_class_expression)
        {
            definition.classes.Add(the_dynamic_class_expression);
            return this;
        }

        /// <summary>
        ///     Add shift calendars to the Shift Calendar Lister.
        /// </summary>
        /// <param name="the_shift_calendar_expression">
        ///     The expression that generates shift calendars from the model that will be part of the Shift Calendars Lister.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarsListerStaticDefinitionBuilder<S> get_calendars_via(Func<S, IEnumerable<ShiftCalendar>> the_shift_calendar_expression)
        {
            definition.create_shift_calendars = the_shift_calendar_expression;
            return this;
        }

        private DynamicShiftCalendarsListerStaticDefinition<S> definition
        {
            get { return _repository.definition; }
        }

        public DynamicShiftCalendarsListerStaticDefinitionBuilder(DynamicShiftCalendarsListerStaticDefinitionRepository<S> the_repository)
        {
            _repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly DynamicShiftCalendarsListerStaticDefinitionRepository<S> _repository;
    }
}