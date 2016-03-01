using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangePalettes.StaticallyDefined.Helpers {

    public class DynamicDateRangePaletteStaticDefinitionHelper<S> {

        public S model { get; set; }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> definition_builder { get; private set; }

        public DynamicDateRangePaletteActionsStaticDefinitionBuilder<S> actions_definition_builder { get; private set; }

 
        public DateRangePalette date_range_palette {
            get { return builder.build( model ); }
        }

        public DynamicDateRangePaletteStaticDefinitionHelper() 
        {
            var repository = new DynamicDateRangePaletteStaticDefinitionRepository<S>();

            definition_builder = new DynamicDateRangePaletteStaticDefinitionBuilder<S>( repository );
            actions_definition_builder = new DynamicDateRangePaletteActionsStaticDefinitionBuilder<S>(repository);
            builder = new BuildDynamicDateRangePaletteFromStaticDefinition<S>(repository);
        }

        private readonly BuildDynamicDateRangePaletteFromStaticDefinition<S> builder;
    }
}