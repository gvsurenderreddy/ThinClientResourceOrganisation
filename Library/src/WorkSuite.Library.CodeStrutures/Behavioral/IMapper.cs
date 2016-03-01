using System;
using System.Linq.Expressions;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{

    /// <summary>
    /// Mapper that copies fields from the entity to the details
    /// </summary>
    /// <typeparam name="D">Details mapped from the entity</typeparam>
    /// <typeparam name="E">Entity that the details is mapped from</typeparam>
    public interface IMapper<D, E>
    {

        /// <summary>
        /// Expression (so that it can be used in an IQueryable LINQ query) that will copies 
        /// field values from the <see cref="{E}"/> to the <see cref="{D}"/>
        /// </summary>
        Expression<Func<E, D>> Map { get; }

    }
}