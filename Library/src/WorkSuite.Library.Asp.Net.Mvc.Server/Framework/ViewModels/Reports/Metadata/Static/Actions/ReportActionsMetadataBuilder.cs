using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportActionsMetadataBuilder<S>  
        : RoutedActionsMetadataBuilder<S,IReportActionMetadataBuilder<S>>
        , IReportActionsMetadataBuilder<S> {

        public ReportActionsMetadataBuilder ( ReportActionMetadataRepository<S> the_repository ) {
            
            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

        protected override IReportActionMetadataBuilder<S> create_action_builder ( ) {
            return new ReportActionMetadataBuilder<S>( repository.Add );
        }

        private readonly ReportActionMetadataRepository<S> repository;
    }
}