using System;
using System.Collections.ObjectModel;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields {

    /// <summary>
    ///     Defintion builder for dynamic tile fields
    /// </summary>
    /// <typeparam name="S">
    ///     The dynamic tile's model type
    /// </typeparam>
    public class DynamicTileFieldStaticDefinitionBuilder<S> {

        /// <summary>
        ///     Add a class that will included on all fields built from this
        /// definition.
        /// </summary>
        /// <param name="the_class">
        ///     The name of the class.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as 
        /// part of a fluent interface.
        /// </returns>
        public DynamicTileFieldStaticDefinitionBuilder<S> add_class
                                                            ( string the_class ) {
            
            definition.classes.Add( m => the_class );
            return this;
        }

        /// <summary>
        ///     Add a class that will included on all fields built from this
        /// definition.
        /// </summary>
        /// <param name="class_expression">
        ///     The expression that generated the name of the class.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as 
        /// part of a fluent interface.
        /// </returns>        
        public DynamicTileFieldStaticDefinitionBuilder<S> add_class
                                                            ( Func<string> class_expression ) {

            definition.classes.Add( m => class_expression() );
            return this;
        }

        /// <summary>
        ///     Add a class that will included on all fields built from this
        /// definition.
        /// </summary>
        /// <param name="dynamic_class_expression">
        ///     The expression that generated the name of the class.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as 
        /// part of a fluent interface.
        /// </returns>        
        public DynamicTileFieldStaticDefinitionBuilder<S> add_class
                                                            ( Func<S,string> dynamic_class_expression ) {

            definition.classes.Add( dynamic_class_expression );
            return this;
        }

        /// <summary>
        ///     Set the tile for fields build from this definition.
        /// </summary>
        /// <param name="the_title">
        ///     The name of the title.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as 
        /// part of a fluent interface.
        /// </returns>
        public DynamicTileFieldStaticDefinitionBuilder<S> title
                                                            ( string the_title ) {

            definition.title = m => the_title;
            return this;
        }

        /// <summary>
        ///     Set the tile for fields build from this definition.
        /// </summary>
        /// <param name="title_expression">
        ///     Expression that will generate the title.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as 
        /// part of a fluent interface.
        /// </returns>
        public DynamicTileFieldStaticDefinitionBuilder<S> title
                                                            ( Func<string> title_expression ) {
            
            definition.title = m => title_expression();
            return this;
        }

        /// <summary>
        ///     Set the tile for fields build from this definition.
        /// </summary>
        /// <param name="dynamic_title_expression">
        ///     Expression that will generate the title.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as 
        /// part of a fluent interface.
        /// </returns>
        public DynamicTileFieldStaticDefinitionBuilder<S> title
                                                            ( Func<S,string> dynamic_title_expression ) {

            definition.title = dynamic_title_expression;
            return this;
        }

        public DynamicTileFieldStaticDefinitionBuilder
                ( string field_name
                , Action<DynamicTileFieldStaticDefinition<S>> add_field_definition ) {

            add_field_definition( (definition = new DynamicTileFieldStaticDefinition<S> {
                field_name = field_name,
                classes = new Collection<Func<S,string>> (),
                title = m => string.Empty,
            }));
        }

        private readonly DynamicTileFieldStaticDefinition<S> definition;
    }
}