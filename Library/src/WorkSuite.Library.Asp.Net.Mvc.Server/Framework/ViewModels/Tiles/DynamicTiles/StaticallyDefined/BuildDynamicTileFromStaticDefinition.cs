using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined {

    /// <summary>
    ///     Builder that will create a dynamic tile from statically defined definition
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the dynamic tile is built from
    /// </typeparam>
    public class BuildDynamicTileFromStaticDefinition<S> {

        /// <summary>
        ///     Builds the tile
        /// </summary>
        /// <param name="model">
        ///     The model that is the source of the dynamic data.
        /// </param>
        /// <returns>
        ///     A tile that has been built from the model.
        /// </returns>
        public Tile build
                        ( S model ) {
            
            return new Tile {
                id = value_or_default( definition.id, model, string.Empty ),
                title = value_or_default( definition.title, model, string.Empty ),
                classes = definition.classes.Select( c => value_or_default( c, model, string.Empty )).ToList(  ),
                url = create_url( definition.url, model ),
                fields = field_definitions.Select( fd => create_field( fd, model )).ToList(),
            };             
        }


        public BuildDynamicTileFromStaticDefinition 
                ( DynamicTileStaticDefinitionRepository<S> the_repository
                , BuildUrlFromDefinition<S> the_url_builder
                , INamedRouteUrlBuilder the_route_builder ) {
            
            repository = Guard.IsNotNull( the_repository, "the_repository" );
            url_builder = Guard.IsNotNull( the_url_builder, "the_url_builder" );
            route_builder = Guard.IsNotNull( the_route_builder, "the_route_builder" );
        }

        private DynamicTileStaticDefinition<S> definition {
            get { return repository.definition; }
        }

        private IEnumerable<DynamicTileFieldStaticDefinition<S>> field_definitions {
            get { return repository.fields; }
        }

        // creates the url for the definition
        private string create_url
                        ( UrlDefinition url_definition
                        , S model ) {

            return url_builder.build( url_definition, model );
        }
        private TileField create_field
                            ( DynamicTileFieldStaticDefinition<S> field_definition 
                            , S model ) {

            return new TileField {
                name = field_definition.field_name,
                classes = field_definition.classes.Select( class_definition => class_definition( model )).ToList(),
                title = field_definition.title( model ),
            };
        }

        // used to safely return the value of an expression or a default value. 
        // By safe I mean avoid null pointer exceptions.
        private string value_or_default
                        ( Func<S,string> expression
                        , S model 
                        , string default_value ) {

            return expression != null ? expression( model ) : default_value;
        }


        // repository used to get the tile definition from
        private readonly DynamicTileStaticDefinitionRepository<S> repository;

        // builder that creates a url from the server
        private readonly BuildUrlFromDefinition<S> url_builder;

        // route builder used to get urls for named routes
        private readonly INamedRouteUrlBuilder route_builder;

    }
}