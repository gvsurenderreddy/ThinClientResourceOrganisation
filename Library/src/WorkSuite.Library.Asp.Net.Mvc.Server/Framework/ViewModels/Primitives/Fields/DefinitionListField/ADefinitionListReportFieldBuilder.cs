using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.DomainTypes.DefinitionList;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DefinitionListField
{
    public class ADefinitionListReportFieldBuilder<S>
                                : Builder<S, ADefinitionListReportField, IEnumerable<DefinitionListElement>>
    {
        public ADefinitionListReportFieldBuilder(IModelMetadata<S> the_model_metadata, FieldMetadata<S> the_field_metadata)
            : base(the_field_metadata, the_model_metadata)
        {
        }

        protected override IEnumerable<DefinitionListElement> property_value(S source, PropertyInfo property)
        {
            var value = property.GetValue(source, null);

            return value as IEnumerable<DefinitionListElement> ?? new List<DefinitionListElement>();
        }
    }
}