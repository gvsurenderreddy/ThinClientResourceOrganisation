using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportModelMetadataRepository<S> : IReportModelMetadataRepository<S> {


        public ReportModelMetadata<S> metadata_for () {
            Guard.IsNotNull( metadata, "metadata" );

            return metadata;
        }

        public void set_metadata ( ReportModelMetadata<S> the_metadata ) {

            Guard.IsNotNull( the_metadata, "the_metadata" );

            metadata = the_metadata;
        }

        private ReportModelMetadata<S> metadata;
    }
}