using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions {

    /// <summary>
    ///     Repository that stores the metadata for a report's actions
    /// </summary>
    /// <typeparam name="S">
    ///     Sepcific report type that the metadat is for
    /// </typeparam>
    public interface IReportActionMetadataRepository<S> 
                        : IRoutedActionMetadataRepository<S, ReportActionMetadata<S>> { }

}