using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportModelMetadataBuilder<S> : IReportModelMetadataBuilder<S> {

        public IReportModelMetadataBuilder<S> id(Func<S, string> generator)
        {
            metadata.id = generator;

            return this;
        }

        public IReportModelMetadataBuilder<S> presenter_id ( string value ) {
            metadata.report_presenter_id = value;
           return this;
        }

        public IReportModelMetadataBuilder<S> title ( string value ) {
            metadata.title = m => value;

            return this;
        }

        public IReportModelMetadataBuilder<S> title(Func<S, string> generator)
        {
            metadata.title = generator;

            return this;
        }

        public IReportModelMetadataBuilder<S> description(string value)
        {
            metadata.description =value;
            return this;
        }

        public IReportModelMetadataBuilder<S> description(Func<S, string> generator)
        {
            metadata.title = generator;

            return this;
        }
        public IReportModelMetadataBuilder<S> field_id_extension ( Func<S, string> genrator ) {
            metadata.field_id_extension = genrator;

            return this;
        }

        public IReportModelMetadataBuilder<S> is_marked_as_hidden ( Func<S,bool> generator ) {
            metadata.is_marked_as_hidden = generator;

            return this;
        }

        public IReportModelMetadataBuilder<S> should_display_discription(Func<S, bool> func)
        {
            metadata.should_display_discription=func;
            return this;
        }

        public ReportModelMetadataBuilder ( ReportModelMetadataRepository<S> repository ) {

            Guard.IsNotNull( repository, "repository" );

            metadata = new ReportModelMetadata<S> {
                id = m => metadata.report_presenter_id,
                title = m => string.Empty,
                is_marked_as_hidden = m => false,                    
            };

            repository.set_metadata( metadata );
        }


        private readonly ReportModelMetadata<S> metadata;

    }
}