using System.Linq;

namespace WorkSuite.Configuration.Persistence.Domain.Configuration {

    /// <summary>
    ///     Repository for the service status history.
    /// </summary>
    public interface IServiceStatusRepository {


        /// <summary>
        ///     all the service status entries in the repository
        /// </summary>
        IQueryable<ServiceStatus> Entities 
                                    { get; }


        /// <summary>
        ///     adds a service status to the repository
        /// </summary>
        /// <param name="entity">
        ///     the service status that is to be added to the respository.
        /// </param>
        void add
                ( ServiceStatus entity );        
    }

}