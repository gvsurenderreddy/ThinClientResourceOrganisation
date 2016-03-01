using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportFieldMetadataBuilder<S> : IReportFieldMetadataBuilder<S> {

        public IReportFieldMetadataBuilder<S> id(string value)
        {
            metadata.id = m => value;

            return this;
        }

        public IReportFieldMetadataBuilder<S> id(Func<S, string> generator)
        {
            metadata.id = generator;
            return this;
        }

        public IReportFieldMetadataBuilder<S> icon(string value)
        {
            metadata.icon = m => value;

            return this;
        }

        public IReportFieldMetadataBuilder<S> icon(Func<S, string> generator)
        {
            metadata.icon = generator;
            return this;
        }

        public IReportFieldMetadataBuilder<S> label ( string value ) {
            metadata.lable = value;

            return this;
        }
       
        public IReportFieldMetadataBuilder<S> is_required ( bool value ) {
            metadata.is_required = value;

            return this;
        }

        public IReportFieldMetadataBuilder<S> is_rich_text(bool value)
        {
            metadata.is_rich_text = value;

            return this;
        }

        public IReportFieldMetadataBuilder<S> is_included ( Func<S, bool> value ) {
            metadata.is_included = value;

            return this;
        }

        public IReportFieldMetadataBuilder<S> humanize () {
            metadata.humanize = true;
            return this;
        }

        public IReportFieldMetadataBuilder<S> is_simple_image()
        {
            metadata.field_type = FieldTypes.SimpleImage;
            return this;
        }

        public IReportFieldMetadataBuilder<S> is_hidden()
        {
            metadata.status = ReportFieldStatus.hidden;

            return this;
        }

        public ReportFieldMetadataBuilder ( Action<ReportFieldMetadata<S>> add_metadata ) {

            metadata = new ReportFieldMetadata<S> {
                is_included =  m => true,  // if we are configuring metadata assume it is to be included on the report
                id = m => string.Empty
            };

            add_metadata( metadata );
        }

        // metadata which is added to the repository

        private readonly ReportFieldMetadata<S> metadata;
    }
}