using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository
{
    public interface ITableFieldMetadataBuilder<S>
    {
        ITableFieldMetadataBuilder<S> id(string value);
        ITableFieldMetadataBuilder<S> id(Func<S, string> generator);
        ITableFieldMetadataBuilder<S> lable(string value);
        ITableFieldMetadataBuilder<S> is_required(bool value);       
    }
}