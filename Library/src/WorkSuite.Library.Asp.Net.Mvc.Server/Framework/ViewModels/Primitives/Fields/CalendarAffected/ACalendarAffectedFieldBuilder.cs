using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.CalendarAffected
{
    public class ACalendarAffectedFieldBuilder<S>
                            : Builder<S, ACalendarAffectedField, IEnumerable<ShiftCalendarOccurencesCountDetails>>
    {
        public ACalendarAffectedFieldBuilder
                            ( IModelMetadata<S> the_model_metadata
                            , FieldMetadata<S> the_field_metadata)
            
            : base(the_field_metadata, the_model_metadata)
        {
        }

        protected override IEnumerable<ShiftCalendarOccurencesCountDetails> property_value
                                                ( S source
                                                , PropertyInfo property)
        {
            Guard.IsNotNull(source, "source");
            Guard.IsNotNull(property, "property");

            var value = property.GetValue(source);

           var source_value = value as IEnumerable<ShiftCalendarOccurencesCountDetails>;

            return value is IEnumerable<ShiftCalendarOccurencesCountDetails>
             

                ? (IEnumerable<ShiftCalendarOccurencesCountDetails>) value

                : (IEnumerable<ShiftCalendarOccurencesCountDetails>)new ShiftCalendarOccurencesCountDetails() 

                { name = source_value.Select(x => x.name).ToString(), count = Convert.ToInt32(source_value.Select(c => c.count)) };

        }
    }
}