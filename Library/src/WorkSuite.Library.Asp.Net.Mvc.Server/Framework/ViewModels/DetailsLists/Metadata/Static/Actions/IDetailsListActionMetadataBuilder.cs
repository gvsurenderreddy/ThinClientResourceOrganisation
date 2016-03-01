using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions {

    /// <summary>
    ///     Builder that allows you to define 
    /// </summary>
     public interface IDetailsListActionMetadataBuilder<S> 
         : IRoutedActionMetadataBuilder<S, IDetailsListActionMetadataBuilder<S>> {}
}