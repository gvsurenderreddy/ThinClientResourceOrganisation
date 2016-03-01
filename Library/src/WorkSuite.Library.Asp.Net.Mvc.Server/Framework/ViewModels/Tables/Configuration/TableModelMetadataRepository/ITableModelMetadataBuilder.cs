using System;
namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository
{
    public interface ITableModelMetadataBuilder<S> {

        ITableModelMetadataBuilder<S> id ( string value );
        ITableModelMetadataBuilder<S> field_id_extension ( Func<S, string> genrator );
        
        ITableModelMetadataBuilder<S> row_details_route_id ( string value );
        ITableModelMetadataBuilder<S> row_details_route_pramameter_factory( Func<S, object> value );
      
    }
}