using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata
{
    public class TableModelMetadata<S> : IModelMetadata<S> {

        /// <summary>
        ///     Use to set the table's id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///     use to identify the route used to build the url for each row.
        /// </summary>
        public string row_details_route_id { get; set; }

        /// <summary>
        ///     Used to generate the route parameters for the url each row.
        /// </summary>
        public Func<S, object> row_details_route_pramameter_factory { get; set; }

        /// <summary>
        ///     This is used to set the id on each row.
        /// </summary>
        public Func<S, string> field_id_extension { get; set; }
    }
}