using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Service.Specification.Helpers.Persistence {

    public class FakeEntityRepository<E,I> : IEntityRepository<E> , IQueryRepository<E> 
        where E : BaseEntity<I> {


        public void throw_exception_on_next_remove () {
            should_throw_execpetion_on_remove = true;
        }


        public FakeEntityRepository 
            ( IdentityProvider<E,I> an_identity_provider ) {

            identity_provider = an_identity_provider;
        }

        public IQueryable<E> Entities {
            get {
                return entities.AsQueryable( );
            }
        }

        public void add ( E entity ) {
            entity.id = next_id( );
            entities.Add( entity );
        }

        public virtual void remove<P> ( P entity ) where P : class {
            var throw_exception = should_throw_execpetion_on_remove;

            should_throw_execpetion_on_remove = false;

            if (throw_exception) throw new Exception(); 

            if (typeof (P) == typeof (E)) {
                entities.Remove( entity as E );
            
            } else {

                try {
                    // We are just swallowing the exception at the moment because we do
                    // not fully understand how to solve this issue.
                    //
                    // The problem occurs with entities that are not roots. They do not have
                    // a repository as they are owned by the root so when you ask for one it
                    // all goes horribly wrong.
                    //
                    // This is just a temporary hack!!! until a more refined solutions is identified.

                    var repository = DependencyResolver.resolve<IEntityRepository<P>>();
                    repository.remove( entity );

                }
                catch (Ninject.ActivationException)
                {
                   // just swallow it for now sorry I will try harder!!   
                }
            }
        }

        public void Update(E entity)
        {
            changes_were_persisted = true;
        }


        public void clear () {
            entities.Clear();
        }

        /// <summary>
        ///     Returns the next id in the sequence for the entity.
        /// </summary>
        /// <returns>
        ///     Next id in the sequence for the entity.
        /// </returns>
        public I next_id () {
            return identity_provider.next( );
        }
        
        /// <summary>
        ///     Adds an entity to the repository without setting 
        /// the identity of the entity.
        /// </summary>
        /// <remarks>
        ///     Add will set the identity of the entity which is not helpful
        /// when trying to set up test data.
        /// </remarks>
        /// <param name="entity">
        ///     The entity that will be added to the repository.
        /// </param>
        public void seed ( E entity ) {

            entities.Add( entity );
        }

        private readonly ICollection<E> entities = new HashSet<E>();
        private readonly IdentityProvider<E, I> identity_provider;

        public bool changes_were_persisted { get; private set; }
        private bool should_throw_execpetion_on_remove = false;
    }

}