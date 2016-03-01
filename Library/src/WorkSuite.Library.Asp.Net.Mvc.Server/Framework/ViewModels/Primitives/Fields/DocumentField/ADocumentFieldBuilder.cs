using System.Reflection;
using WTS.WorkSuite.Library.DomainTypes.Documents;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DocumentField
{
    public class ADocumentFieldBuilder<S> : Builder<S, ADocumentField, string>
    {
        public ADocumentFieldBuilder(IModelMetadata<S> the_model_metadata
                                     , FieldMetadata<S> the_field_metadata)
            : base(the_field_metadata
                   , the_model_metadata)
        {
            
        }


        protected override string property_value(S source, PropertyInfo property)
        {

            Guard.IsNotNull(source, "source");
            Guard.IsNotNull(property, "property");

            // to do: set it to the null text value if not set
            var value = property.GetValue(source, null);

            var source_value = (DocumentId)value;

            return source_value;

        }
    }
}
