using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public interface IReportActionMetadataBuilder<S>
        : IRoutedActionMetadataBuilder<S, IReportActionMetadataBuilder<S>> {}
}