using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.Repository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportActionMetadataRepository<S> 
        : RoutedActionMetadataRepository<S,ReportActionMetadata<S>> 
        , IReportActionMetadataRepository<S> {}

}