using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Allows a Dynamic Shift Calendar static definition to be built.
    /// </summary>
    /// <typeparam name="S">
    ///     The model that the dynamic Shift Calendar is built from.
    /// </typeparam>
    public class DynamicShiftCalendarStaticDefinitionBuilder<S>
    {
        /// <summary>
        ///     Sets the title to be the supplied title for all Shift Calendar.
        /// </summary>
        /// <param name="the_value">
        ///     The value that the title should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> title(string the_value)
        {
            definition.title = m => the_value;

            return this;
        }

        /// <summary>
        ///     Sets the title to be the supplied title for the Shift Calendar.
        /// </summary>
        /// <param name="the_title_expression">
        ///     The expression that generates a value that the title should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> title(Func<string> the_title_expression)
        {
            definition.title = m => the_title_expression();

            return this;
        }

        /// <summary>
        ///     Sets the title to be the supplied title for the Shift Calendar.
        /// </summary>
        /// <param name="the_dynamic_title_expression">
        ///     The expression that generates a value from the model that the title should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> title(Func<S, string> the_dynamic_title_expression)
        {
            definition.title = the_dynamic_title_expression;

            return this;
        }

        /// <summary>
        ///     Sets the start_date from which its underlying data is returned from.
        /// </summary>
        /// <param name="the_dynamic_expression">
        ///     The expression that generates a value from the model that the start date should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> start_date(Func<S, DateTime> the_dynamic_expression)
        {
            definition.start_date = the_dynamic_expression;

            return this;
        }

        /// <summary>
        ///     Sets the number of days range from which its underlying data is returned for.
        /// </summary>
        /// <param name="the_dynamic_expression">
        ///     The expression that generates a value from the model that the number_of_days should be.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> number_of_days_range(Func<S, ShiftCalendarRange> the_dynamic_expression)
        {
            definition.number_of_days_range = the_dynamic_expression;

            return this;
        }

        /// <summary>
        /// Sets the Shift patterns needed to buid the shift pattern grid
        /// </summary>
        /// <param name="the_dynamic_expression"></param>
        /// <returns></returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> patterns(Func<S, IEnumerable<IShiftPattern>> the_dynamic_expression)
        {
            definition.patterns = the_dynamic_expression;

            return this;
        }

        /// <summary>
        ///     Adds a class to the Shift Calendar.
        /// </summary>
        /// <param name="the_value">
        ///     The class that will be added to the Shift Calendar.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> add_class(string the_value)
        {
            definition.classes.Add(m => the_value);

            return this;
        }

        /// <summary>
        ///     Adds a class to the Shift Calendar.
        /// </summary>
        /// <param name="the_class_expression">
        ///     The expression that generates a class that will be added to the Shift Calendar.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> add_class(Func<string> the_class_expression)
        {
            definition.classes.Add(m => the_class_expression());

            return this;
        }

        /// <summary>
        ///     Adds a class to the Shift Calendar.
        /// </summary>
        /// <param name="the_dynamic_class_expression">
        ///     The expression that generates a class from the model that will be added to the Shift Calendar.
        /// </param>
        /// <returns>
        ///     Returns the Builder itself so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicShiftCalendarStaticDefinitionBuilder<S> add_class(Func<S, string> the_dynamic_class_expression)
        {
            definition.classes.Add(the_dynamic_class_expression);

            return this;
        }

        private DynamicShiftCalendarStaticDefinition<S> definition
        {
            get { return _repository.definition; }
        }

        public DynamicShiftCalendarStaticDefinitionBuilder(DynamicShiftCalendarStaticDefinitionRepository<S> the_repository)
        {
            _repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly DynamicShiftCalendarStaticDefinitionRepository<S> _repository;
    }
}