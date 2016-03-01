using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Model
{
    public class DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder<S>
    {

        public DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder<S> title(string dynamic_expression)
        {
            definition.title = dynamic_expression;
            return this;
        }
        

        public DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder<S> add_class(string dynamic_class_expression)
        {

            definition.classes.Add(dynamic_class_expression);
            return this;
        }

        public DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder(DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinition definition
        {
            get { return repository.definition; }
        }

        private readonly DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S> repository;
    }
}