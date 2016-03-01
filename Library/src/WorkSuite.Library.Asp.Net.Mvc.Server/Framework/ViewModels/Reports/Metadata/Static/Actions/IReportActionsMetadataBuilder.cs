using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public interface IReportActionsMetadataBuilder<S>
        : IRoutedActionsMetadataBuilder<S,IReportActionMetadataBuilder<S>>{}   
}