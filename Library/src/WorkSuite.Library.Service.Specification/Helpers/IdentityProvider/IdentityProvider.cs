using WorkSuite.Library.Persistence;

namespace WorkSuite.Library.Service.Specification.Helpers.IdentityProvider {

    public abstract class IdentityProvider<E,I> 
        where E : BaseEntity<I> {
         
        public void set_indentity ( E entity ) {
            entity.id = next();
        }

        public abstract I next();
    }

}