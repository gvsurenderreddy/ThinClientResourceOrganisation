using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions {

    public class DetailsListActionsMetadataBuilder<S>
            : RoutedActionsMetadataBuilder<S,IDetailsListActionMetadataBuilder<S>>
            , IDetailsListActionsMetadataBuilder<S> {

        public DetailsListActionsMetadataBuilder 
            ( DetailsListActionMetadataRepository<S> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );
            
            repository = the_repository;
        }

        protected override IDetailsListActionMetadataBuilder<S> create_action_builder ( ) {
            return new DetailsListActionMetadataBuilder<S>( repository.Add  );
        }

        private readonly DetailsListActionMetadataRepository<S> repository;

    }
}