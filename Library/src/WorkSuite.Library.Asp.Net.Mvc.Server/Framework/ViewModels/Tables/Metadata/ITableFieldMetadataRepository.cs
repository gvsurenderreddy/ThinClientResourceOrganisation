using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata
{
    public interface ITableFieldMetadataRepository<S> : Primitives.Fields.Metadata.IRepository<TableFieldMetadata<S>,S> {

        
        IEnumerable<TableFieldMetadata<S>> fields { get; }

    }
}