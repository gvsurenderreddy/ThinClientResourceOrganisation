using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions {

    /// <summary>
    ///     Abstract tile metadata builder.  
    /// </summary>
    /// <remarks>
    ///     This contains all the methods needed to build tile metadata the class is generic abstact so we 
    /// can extend the fluent interdace in descendent classes, the return type of the fluent methods has to be 
    /// the descendent type or extended method are not presented from fluent methods defined in this class
    /// </remarks>
    /// <typeparam name="ConcreteBuilder">
    ///     The descendent builder that is returned by the fluent interface methods.
    /// </typeparam>
    public abstract class BaseStaticTileStaticDefinitionBuilder<ConcreteBuilder>
                            where ConcreteBuilder : BaseStaticTileStaticDefinitionBuilder<ConcreteBuilder> {

        /// <summary>
        ///     Sets the id that you want a tile to have.
        /// </summary>
        /// <param name="the_id">
        ///     The value of the id for a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The builder so that the method is part of the builders fluent interface.
        /// </returns>
        public ConcreteBuilder id
                                ( string the_id ) {

            metadata.id = () => the_id;
            return (ConcreteBuilder)this;
        }
        
        /// <summary>
        ///     Sets the id that you want a tile to have.
        /// </summary>
        /// <param name="the_id_expression">
        ///     An expression that will generate an id for a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The builder so that the method is part of the builders fluent interface.
        /// </returns>
        public ConcreteBuilder id
                                ( Func<string> the_id_expression ) {

            metadata.id = the_id_expression;
            return (ConcreteBuilder)this;
        }
        
        
        
        /// <summary>
        ///     Sets the title of a tile
        /// </summary>
        /// <param name="the_title">
        ///     The value of the title for a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The StaticTileModelMetadataBuilder so that the method can be used
        /// as part of the fluent interface.
        /// </returns>
        public ConcreteBuilder title
                                ( string the_title ) {
            
            metadata.title = () => the_title;
            return (ConcreteBuilder)this;
        }
        
        /// <summary>
        ///     Sets the title of a tile
        /// </summary>
        /// <param name="the_title_expression">
        ///     An expression that will generate the title for a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The StaticTileModelMetadataBuilder so that the method can be used
        /// as part of the fluent interface.
        /// </returns>
        public ConcreteBuilder title
                                ( Func<string> the_title_expression ) {
            
            metadata.title = the_title_expression;
            return (ConcreteBuilder)this;
        }
        
        
        /// <summary>
        ///     Sets the url that you want a tile to have.
        /// </summary>
        /// <param name="the_url">
        ///     The value of the url for a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The builder so that the method is part of the builders fluent interface.
        /// </returns>
        public ConcreteBuilder url
                                ( string the_url ) {

            metadata.url = () => the_url;
            return (ConcreteBuilder)this;
        }
        
        
        /// <summary>
        ///     Sets the url of a tile.
        /// </summary>
        /// <param name="the_url_expression">
        ///     An expression that will generate the url for a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The StaticTileModelMetadataBuilder so that the method can be used
        /// as part of the fluent interface.
        /// </returns>
        public ConcreteBuilder url
                                ( Func<string> the_url_expression ) {
        
            metadata.url = the_url_expression;
            return (ConcreteBuilder)this;
        }
        
        /// <summary>
        ///     Adds a class to the tile. You are allowed to add multiple classes to a tile. 
        /// </summary>
        /// <param name="the_class">
        ///     The name of the class that you want to add to tiles that are created from this metadata.
        /// </param>
        /// <returns>
        ///     The StaticTileModelMetadataBuilder so that the method can be used
        /// as part of the fluent interface.
        /// </returns>
        public ConcreteBuilder add_class
                                ( string the_class ) {
            
            classes.Add(() => the_class);
            return (ConcreteBuilder)this;
        }
        
        /// <summary>
        ///     Adds a class to the tile. You are allowed to add multiple classes to a tile. 
        /// </summary>
        /// <param name="the_class_expression">
        ///     An expression that will generate a class that should be added to a tile created from this metadata.
        /// </param>
        /// <returns>
        ///     The StaticTileModelMetadataBuilder so that the method can be used
        /// as part of the fluent interface.
        /// </returns>
        public ConcreteBuilder add_class 
                                ( Func<string> the_class_expression ) {
            
            classes.Add(the_class_expression);
            return (ConcreteBuilder)this;
        }
        
        /// <summary>
        ///     Builds the metdata with all the options that have been specified. This
        /// returns a new instance of the metadata so configuration methods called on
        /// the metadata builder will not affect an instance returned from an earlier 
        /// call to this mehtod.
        /// </summary>
        /// <returns>
        ///     An instance of the model metadta.
        /// </returns>
        public StaticTileStaticDefinition build() {

            // create a new instance of the metadata so that configuraton 
            // methods that are called after a build does not affect the
            // the metadata returned form this method (avoiding side effects).           
            return new StaticTileStaticDefinition
            {
                id = metadata.id,
                url = metadata.url,
                title = metadata.title,
                classes = classes.ToList(),
            };
        }
        
        private readonly StaticTileStaticDefinition metadata = new StaticTileStaticDefinition();
        private readonly List<Func<string>> classes = new List<Func<string>>();
    }
}