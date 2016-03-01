using System;
using System.Linq.Expressions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields {

    public class DynamicTileFieldsStaticDefinitionBuilder<S> {

        public DynamicTileFieldStaticDefinitionBuilder<S> add_field_from_propertry<P>
                                                            ( Expression<Func<S, P>> property_expression ) {

            // create the a definition builder for the property
            return new DynamicTileFieldStaticDefinitionBuilder<S> (
                property_expression.property_name(),
                d => definition_repository.fields.Add( d )
            );                
        }

        public DynamicTileFieldsStaticDefinitionBuilder 
                ( DynamicTileStaticDefinitionRepository<S> the_definition_repository ) {
            
            definition_repository = Guard.IsNotNull( the_definition_repository, "the_defintion_repository");
        }

        private DynamicTileStaticDefinitionRepository<S> definition_repository;
    }
}