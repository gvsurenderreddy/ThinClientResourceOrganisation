using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportActionMetadataBuilder<S> 
        : RoutedActionMetadataBuilder<S,IReportActionMetadataBuilder<S>,ReportActionMetadata<S>>
        , IReportActionMetadataBuilder<S> {

        public ReportActionMetadataBuilder
            ( Action<ReportActionMetadata<S>> add_to_repository ) : base( add_to_repository) {}
        
        protected override IReportActionMetadataBuilder<S> builder {
            get { return this; }
        }
    }
}