using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Model
{
    public class DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S>
    {

        public DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S> title(string dynamic_expression)
        {
            definition.title = dynamic_expression;
            return this;
        }

        public DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S> shift_title(Func<S, string> dynamic_description_expression)
        {
            definition.shift_title = dynamic_description_expression;
            return this;
        }

        public DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S> time_period(Func<S, TimePeriod> dynamic_description_expression)
        {
            definition.time_period = dynamic_description_expression;
            return this;
        }

        public DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S> breaks(Func<S, IEnumerable<ITimeAllocationBreak>> dynamic_breaks_expression)
        {
            definition.breaks = dynamic_breaks_expression;
            return this;
        }

        public DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S> add_class(string dynamic_class_expression)
        {

            definition.classes.Add(dynamic_class_expression);
            return this;
        }

        public DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder(DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");

        }

        private DynamicShiftTimeAllocationPaletteModelStaticDefinition<S> definition
        {
            get { return repository.definition; }
        }

        private readonly DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S> repository;
    }
}