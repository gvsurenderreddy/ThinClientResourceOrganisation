using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata {

    public interface IModelMetadata<S> {

        /// <summary>
        ///     Extends the property id so that
        /// </summary>
        Func<S,string> field_id_extension { get; set; }
    }
}