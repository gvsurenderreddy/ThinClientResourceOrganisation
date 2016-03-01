using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.DateRangeBars.StaticallyDefined.Helpers {

    public class DynamicDateRangeBarStaticDefinitionHelper<S> {

        public S model { get; set; }

        public DynamicDateRangeBarStaticDefinitionBuilder<S> definition_builder { get; private set; }

 
        public DateRangeBar date_range_bar {
            get { return builder.build( model ); }
        }

        public DynamicDateRangeBarStaticDefinitionHelper() 
        {
            var repository = new DynamicDateRangeBarStaticDefinitionRepository<S>();

            definition_builder = new DynamicDateRangeBarStaticDefinitionBuilder<S>( repository );
            builder = new BuildDynamicDateRangeBarFromStaticDefinition<S>(repository);
        }

        private readonly BuildDynamicDateRangeBarFromStaticDefinition<S> builder;
    }
}