using System.Data.Entity;
using System.Data.Entity.SqlServer;
using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.Library.EntityFramework.Contexts;
using WTS.WorkSuite.Library.EntityFramework.Contexts.ConnectionStringProviders;

namespace WTS.WorkSuite.Persistence.EF.Infrastructure {

    /// <summary>
    ///     Worksuite configuration database context
    /// </summary>
    public class WorkSuiteContext 
                    : CompositeContext {


        /// <inheritdoc/>
        public WorkSuiteContext 
                       ( IModelConfiguration the_model_configuration 
                       , IConnectionStringProvider connection_string_provider ) 
                : base ( the_model_configuration
                       , connection_string_provider ) { }
    }

    /// <summary>
    ///     Worksuite's entity frame database configuration 
    /// </summary>
    /// <remarks>
    ///     This has been introduce as part of the upgrade to Entity Framework version 6.  We
    /// are trying to keep all configuation informtaion out of the web.config file.  Note - This will
    /// cause us a problem if we want to have different contexts in the same application as you are apparently
    /// only allows one ( I have not confirmed this it is just from the blog posts that I have read ).  This
    /// may be a problem for us as we expand our use of the micro service concept in the service layer but
    /// do not treat each domain as a sepaate service.
    /// </remarks>
    public class WorkSuiteContextConfiguration
                    : DbConfiguration {

        protected internal WorkSuiteContextConfiguration () {
            
            SetProviderServices
                ( SqlProviderServices.ProviderInvariantName
                , SqlProviderServices.Instance );
        }

    }
}