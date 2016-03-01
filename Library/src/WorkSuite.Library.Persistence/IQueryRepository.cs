using System.Linq;

namespace WorkSuite.Library.Persistence
{
    public interface IQueryRepository<E>
    {
        /// <summary>
        ///     All the entities that are stored in the repository. 
        /// </summary>
        IQueryable<E> Entities { get; }
    }
}