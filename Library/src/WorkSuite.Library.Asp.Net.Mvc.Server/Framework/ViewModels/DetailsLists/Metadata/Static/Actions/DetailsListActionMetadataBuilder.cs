using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions {
    
    public class DetailsListActionMetadataBuilder<S> 
        : RoutedActionMetadataBuilder<S,IDetailsListActionMetadataBuilder<S>,DetailsListActionMetadata<S>>
        , IDetailsListActionMetadataBuilder<S> {

        public DetailsListActionMetadataBuilder
            ( Action<DetailsListActionMetadata<S>> add_to_repository ) : base( add_to_repository) {}
        
        protected override IDetailsListActionMetadataBuilder<S> builder {
            get { return this; }
        }
    }
}