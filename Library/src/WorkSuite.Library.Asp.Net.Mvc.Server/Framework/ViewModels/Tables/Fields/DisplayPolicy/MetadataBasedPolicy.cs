using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields.DisplayPolicy {

    public class MetadataBasedPolicy<S> : IShouldBeDisplayedOnTable<S>  {

        public bool decide_for ( PropertyInfo context ) {
            var metadata = repository.metadata_for( context );

            return metadata.is_included;
        }


        public MetadataBasedPolicy 
            ( ITableFieldMetadataRepository<S> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

        private readonly ITableFieldMetadataRepository<S> repository;

    }

}