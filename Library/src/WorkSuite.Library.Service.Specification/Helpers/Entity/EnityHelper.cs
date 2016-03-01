using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Service.Specification.Helpers.Entity {

    public abstract class EnityHelper<E,Ei,Eb,Er>
                    where E  : BaseEntity<Ei>
                    where Eb : IEntityBuilder<E>
                    where Er : FakeEntityRepository<E,Ei> {

        
        /// <summary>
        ///     Create a new instance of the entity builder and adds
        /// the entity that is being built to the repository. 
        /// </summary>
        /// <returns>
        ///     The entity builder
        /// </returns>
        public Eb add( ) {
            var result = DependencyResolver.resolve<Eb>(  );

            result.entity.id = repository.next_id();
            repository.seed( result.entity );

            return result;
        }

        public void clear () {
            repository.clear();
        }

        public IEnumerable<E> entities {
            get {
                return repository.Entities;
            }
        }


        protected Er repository {
            get {
                return ( repository_ ?? (repository_ = DependencyResolver.resolve<Er>(  )));
            }
        }

        
        private Er repository_;

    }

}