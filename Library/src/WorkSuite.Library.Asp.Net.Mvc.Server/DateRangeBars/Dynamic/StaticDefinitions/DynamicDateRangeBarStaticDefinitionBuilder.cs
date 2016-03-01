using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions
{
    public class DynamicDateRangeBarStaticDefinitionBuilder<S>
    {
        public DynamicDateRangeBarStaticDefinitionBuilder<S> start_date(DateTime value)
        {
            definition.start_date = m => value;
            return this;
        }

        public DynamicDateRangeBarStaticDefinitionBuilder<S> start_date(Func<DateTime> expression)
        {
            definition.start_date = m => expression();
            return this;
        }

        public DynamicDateRangeBarStaticDefinitionBuilder<S> start_date(Func<S, DateTime> dynamic_expression)
        {
            definition.start_date = dynamic_expression;
            return this;
        }

        public DynamicDateRangeBarStaticDefinitionBuilder<S> date_range(Func<S, ShiftCalendarRange> dynamic_expression)
        {
            definition.selected_range = dynamic_expression;
            return this;
        }

        public DynamicDateRangeBarStaticDefinitionBuilder(DynamicDateRangeBarStaticDefinitionRepository<S> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private DynamicDateRangeBarStaticDefinition<S> definition
        {
            get { return repository.definition; }
        }

        private readonly DynamicDateRangeBarStaticDefinitionRepository<S> repository;
    }
}