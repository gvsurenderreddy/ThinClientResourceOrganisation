using System;
using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.BooleanField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.CalendarAffected;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DateRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DefinitionListField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DocumentField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DurationRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.FreeTextField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ImageField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.MultiLineFields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ReadOnlyField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ServiceStateField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.TimeRequestField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.DefinitionList;
using WTS.WorkSuite.Library.DomainTypes.Documents;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.FreeText;
using WTS.WorkSuite.Library.DomainTypes.Images;
using WTS.WorkSuite.Library.DomainTypes.ReadonlyText;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors
{
    public abstract class Factory<S, M> where M : FieldMetadata<S>
    {
        public Field create(S source, PropertyInfo property)
        {
            // get the appropriate field build for the property
            var builder = builder_for(property);

            Guard.IsNotNull(builder, "builder");

            // build the instance based on the builder
            return builder.build(source, property);
        }

        protected Factory
            (Models.Metadata.IRepository<S, IModelMetadata<S>> the_model_metadata_repository
            , Fields.Metadata.IRepository<M, S> the_field_metadata_repository)
        {
            Guard.IsNotNull(the_model_metadata_repository, "the_model_metadata_repository");
            Guard.IsNotNull(the_field_metadata_repository, "the_field_metadata_repository");

            model_metadata_repository = the_model_metadata_repository;
            field_metadata_repository = the_field_metadata_repository;
        }

        protected virtual IBuilder<S> builder_for(PropertyInfo property)
        {
            // to do: introduce a field type property to the presentation meta_data
            //        and use that as the primary identification as to which builder
            //        to use have a fallback position of using the type from the property.
            var model_metadata = model_metadata_repository.metadata_for();
            var property_metadata = field_metadata_repository.metadata_for(property);

            if (property.PropertyType.IsAssignableFrom(typeof(bool)))
            {
                return new ABooleanReportFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (property.PropertyType.IsAssignableFrom(typeof(IEnumerable<string>)))
            {
                return new AMultilineStringReportFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (property.PropertyType.IsAssignableFrom(typeof(IEnumerable<DefinitionListElement>)))
            {
                return new ADefinitionListReportFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (Attribute.IsDefined(property, typeof(FreeTextAttribute)))
            {
                return new AFreeTextStringReportFieldBuilder<S>(model_metadata, property_metadata);
            }
            if (property.PropertyType.IsAssignableFrom(typeof(DateRequest)))
            {
                return new ADateRequestFieldBuilder<S>(model_metadata, property_metadata);
            }
            if (property.PropertyType.IsAssignableFrom(typeof(ReadOnly)))
            {
                return new AReadOnlyFieldBuilder<S>(model_metadata, property_metadata);
            }
            if (property.PropertyType.IsAssignableFrom(typeof(ImageId)))
            {
                return new AnImageFieldBuilder<S>(model_metadata, property_metadata);
            }
            if (property.PropertyType.IsAssignableFrom(typeof(DocumentId)))
            {
                return new ADocumentFieldBuilder<S>(model_metadata, property_metadata);
            }
            if (property.PropertyType.IsAssignableFrom(typeof(ServiceState)))
            {
                return new ServiceStateFieldBuilder<S>(model_metadata, property_metadata);
            }
            if (property.PropertyType.IsAssignableFrom(typeof(TimeRequest)))
            {
                return new ATimeRequestFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (property.PropertyType.IsAssignableFrom(typeof(DurationRequest)))
            {
                return new ADurationRequestFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (property.PropertyType.IsAssignableFrom(typeof(RGBColourRequest)))
            {
                return new ARgbColourRequestFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (property.PropertyType.IsAssignableFrom(typeof(RgbColour)))
            {
                return new ARgbColourFieldBuilder<S>(model_metadata, property_metadata);
            }

            if (property.PropertyType.IsAssignableFrom(typeof(IEnumerable<ShiftCalendarOccurencesCountDetails>)))
            {
                return new ACalendarAffectedFieldBuilder<S>(model_metadata, property_metadata);
            }
            return new AStringReportFieldBuilder<S>(model_metadata, property_metadata);
        }

        // used to get the field metadata
        protected readonly Fields.Metadata.IRepository<M, S> field_metadata_repository;

        // used to get the model metadata
        protected readonly Models.Metadata.IRepository<S, IModelMetadata<S>> model_metadata_repository;
    }
}