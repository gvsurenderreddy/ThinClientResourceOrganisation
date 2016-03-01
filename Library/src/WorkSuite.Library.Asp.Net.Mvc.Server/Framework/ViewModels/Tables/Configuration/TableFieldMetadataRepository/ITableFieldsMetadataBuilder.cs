using System;
using System.Linq.Expressions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository
{
    public interface ITableFieldsMetadataBuilder<S>
    {
        ITableFieldMetadataBuilder<S> for_field<P>(Expression<Func<S, P>> property);
    }
}