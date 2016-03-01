using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model
{
    public class DynamicDateRangePaletteStaticDefinitionBuilder<S>
    {

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> title(string value)
        {
            definition.title = m => value;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> title(Func<string> expression)
        {
            definition.title = m => expression();
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> title(Func<S, string> dynamic_expression)
        {
            definition.title = dynamic_expression;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> calendar_start_date(DateTime value)
        {
            definition.calendar_start_date = m => value;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> calendar_start_date(Func<DateTime> expression)
        {
            definition.calendar_start_date = m => expression();
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> calendar_start_date(Func<S, DateTime> dynamic_expression)
        {
            definition.calendar_start_date = dynamic_expression;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> selected_start_date(DateTime value)
        {
            definition.selected_start_date = m => value;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> selected_start_date(Func<DateTime> expression)
        {
            definition.selected_start_date = m => expression();
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> selected_start_date(Func<S, DateTime> dynamic_expression)
        {
            definition.selected_start_date = dynamic_expression;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder<S> selected_range(Func<S, ShiftCalendarRange> dynamic_expression)
        {
            definition.selected_range = dynamic_expression;
            return this;
        }

        public DynamicDateRangePaletteStaticDefinitionBuilder(DynamicDateRangePaletteStaticDefinitionRepository<S> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private DynamicDateRangePaletteStaticDefinition<S> definition
        {
            get { return repository.definition; }
        }

        private readonly DynamicDateRangePaletteStaticDefinitionRepository<S> repository;
    }
}