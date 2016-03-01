using System.Reflection;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.Models.Reports {

    /// <summary>
    ///     Stores the presentation metadata for a model
    /// </summary>
    /// <typeparam name="S">
    ///     The model that the metadata is for.
    /// </typeparam>
    public interface IModelMetadataRepository<S>  {

        /// <summary>
        ///     Metadata that is for the model
        /// </summary>
        ModelMetadata<S> metadata_for_model { get; }

        /// <summary>
        ///     Gets the metadata for one of the models properties. 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        PropertyMetadata<S> metadata_for( PropertyInfo property );

    }
}