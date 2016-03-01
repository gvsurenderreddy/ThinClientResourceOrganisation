
namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions {

    public class DynamicDateRangeBarStaticDefinitionRepository<S> {

        public DynamicDateRangeBarStaticDefinition<S> definition { get; private set; }


        public DynamicDateRangeBarStaticDefinitionRepository()
        {
            definition = new DynamicDateRangeBarStaticDefinition<S> ();
        }


    }
}