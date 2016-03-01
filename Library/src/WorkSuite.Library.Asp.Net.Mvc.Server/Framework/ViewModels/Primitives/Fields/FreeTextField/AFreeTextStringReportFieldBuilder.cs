using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.FreeTextField
{
    public class AFreeTextStringReportFieldBuilder<S> : Builder<S, AFreeTextStringReportField, string>
    {
        public AFreeTextStringReportFieldBuilder(IModelMetadata<S> the_model_metadata,FieldMetadata<S> the_field_metadata) 
            : base(the_field_metadata, the_model_metadata)
        {
        }

        protected override string property_value(S source, PropertyInfo property)
        {
            Guard.IsNotNull(source, "source");
            Guard.IsNotNull(property, "property");

            // to do: set it to the null text value if not set
            var value = property.GetValue(source, null);

            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }
    }
}