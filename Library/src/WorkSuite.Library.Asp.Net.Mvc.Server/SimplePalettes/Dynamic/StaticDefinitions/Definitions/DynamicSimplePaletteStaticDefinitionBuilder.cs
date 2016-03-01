using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions {


    /// <summary>
    ///     Allows a Dynamic Content Header static definition to be built.
    /// </summary>
    /// <typeparam name="S">
    ///     The model that the dynamic content is built from.
    /// </typeparam>
    public class DynamicSimplePaletteStaticDefinitionBuilder<S> {

        /// <summary>
        ///     Set the title to be the supplied title for all Content headers 
        /// built from this definition.
        /// </summary>
        /// <param name="value">
        ///     the value that the title should be.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> title
                                                                ( string value ) {
            definition.title = m => value;
            return this;
        }

        /// <summary>
        ///     Set the title to be the supplied title for all Content headers 
        /// built from this definition.
        /// </summary>
        /// <param name="title_expression">
        ///     An expression that will generate a value.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> title
                                                                ( Func<string> title_expression ) {
            definition.title = m => title_expression();
            return this;
        }

        /// <summary>
        ///     Set the title to be the supplied title for all Content headers 
        /// built from this definition.
        /// </summary>
        /// <param name="dynamic_title_expression">
        ///     An expression that will generate a value from the model.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> title
                                                                ( Func<S,string> dynamic_title_expression ) {
            definition.title = dynamic_title_expression;
            return this;
        }


        /// <summary>
        ///     Set the title to be the supplied title for all Content headers 
        /// built from this definition.
        /// </summary>
        /// <param name="value">
        ///     the value that the title should be.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> description
                                                                (string value)
        {
            definition.description = m => value;
            return this;
        }

        /// <summary>
        ///     Set the title to be the supplied title for all Content headers 
        /// built from this definition.
        /// </summary>
        /// <param name="description_expression">
        ///     An expression that will generate a value.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> description
                                                                (Func<string> description_expression)
        {
            definition.description = m => description_expression();
            return this;
        }

        /// <summary>
        ///     Set the title to be the supplied title for all Content headers 
        /// built from this definition.
        /// </summary>
        /// <param name="dynamic_description_expression">
        ///     An expression that will generate a value from the model.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> description
                                                                (Func<S, string> dynamic_description_expression)
        {
            definition.description = dynamic_description_expression;
            return this;
        }


        /// <summary>
        ///     Add a class to the simple palette
        /// </summary>
        /// <param name="value">
        ///     the class that will be added to the simple palette.
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> add_class
                                                                ( string value ) {

            definition.classes.Add( m => value );
            return this;
        }

        /// <summary>
        ///     Add a class to the simple palette
        /// </summary>
        /// <param name="class_expression">
        ///     expression that generate the class
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> add_class
                                                                ( Func<string> class_expression ) {

            definition.classes.Add(m => class_expression());
            return this;
        }

        /// <summary>
        ///     Add a class to the simple palette
        /// </summary>
        /// <param name="dynamic_class_expression">
        ///     expression that generate the class
        /// </param>
        /// <returns>
        ///     The builder so the mehtod can be used as part of a fluent interface
        /// </returns>
        public DynamicSimplePaletteStaticDefinitionBuilder<S> add_class
                                                                (Func<S,string> dynamic_class_expression) {

            definition.classes.Add( dynamic_class_expression );
            return this;
        }

        public DynamicSimplePaletteStaticDefinitionBuilder 
                ( DynamicSimplePaletteStaticDefinitionRepository<S> the_repository ) {

            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        private DynamicSimplePaletteStaticDefinition<S> definition {
            get { return repository.definition; }
        }

        private readonly DynamicSimplePaletteStaticDefinitionRepository<S> repository;
    }
}