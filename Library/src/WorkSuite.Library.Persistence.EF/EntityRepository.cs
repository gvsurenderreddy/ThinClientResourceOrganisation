﻿using System.Data.Entity;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Persistence.EF {

    /// <summary>
    ///     Entity framework implementation of the Repository
    /// </summary>
    /// <typeparam name="E">
    ///     Entity type the repository is for.
    /// </typeparam>
    public class EntityRepository<E> 
                    : IEntityRepository<E> 
            where E : class {


        public EntityRepository ( DbContext db_context  ) {

            Guard.IsNotNull( db_context, "db_context" );
            
            context = db_context;
        }

        /// <inheritdoc/>
        public IQueryable<E> Entities { get { return context.Set<E>(  ); }}

        /// <inheritdoc/>
        public void add ( E entity ) {
            context.Set<E>().Add( entity );
        }

        /// <inheritdoc/>
        public void remove<P> ( P entity ) where P : class {
            context.Set<P>().Attach( entity );
            context.Entry( entity ).State = EntityState.Deleted;
            context.Set<P>().Remove( entity );
        }

        public void Update(E entity)
        {
            context.Set<E>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        private readonly DbContext context;
    }

}