using System;
using System.Linq;
using System.Linq.Expressions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Persistence {

    /// <summary>
    ///     Repository interface for entities that a persistence layer must implement.
    /// </summary>
    /// <typeparam name="E">
    ///     The entity type
    /// </typeparam>
    public interface IEntityRepository<E> {
        
        /// <summary>
        ///     All the entities that are stored in the repository. 
        /// </summary>
        IQueryable<E> Entities { get; }


        /// <summary>
        ///     Adds an entity to the repository. This has the 
        /// side effect of setting the entity's identity.
        /// </summary>         
        /// <param name="entity">
        ///     The entity to be added to the repository.
        /// </param>
        void add ( E entity );


        /// <summary>
        ///     Permanently removes an entity from the repository. This 
        /// means that the entity will no longer appear in the repositories
        /// Entities collection.
        /// </summary>         
        /// <param name="entity">
        ///     The entity to be removed from the repository.
        /// </param>
        void remove<P> ( P entity ) where P : class;


        /// <summary>
        /// Update a T type entity
        /// </summary>
        /// <param name="entity">entity of T type</param>  
        void Update (E entity);


    }

    public static class EntityRepositoryExtensions {
        /// <summary>
        ///     Find a single entity object of E type using predicated condition
        /// </summary>
        /// <param name="repository">
        ///     The repository that entity should be found from
        /// </param>
        /// <param name="where">
        ///     predicated condition
        /// </param>  
        /// <returns>
        ///     entity object of E type
        /// </returns>
        public static Maybe<E> GetSingle<E>
                                ( this IEntityRepository<E> repository
                                , Expression<Func<E, bool>> where ) {

            var result = repository
                            .Entities
                            .Where( where )
                            .SingleOrDefault( )
                            ;

            return result != null
                    ? new Just<E>( result ) as Maybe<E> 
                    : new Nothing<E>()
                    ;
        }
    }
}