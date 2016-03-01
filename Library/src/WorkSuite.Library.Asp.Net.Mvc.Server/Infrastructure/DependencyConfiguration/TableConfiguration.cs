using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class TableConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
             
            kernel
                .Bind(typeof(ITableModelMetadataBuilder<>))
                .To(typeof(TableModelMetadataBuilder<>))
                .InScope( scope )
                ;

            kernel
                .Bind( typeof(ITableFieldsMetadataBuilder<>))
                .To(typeof(TableFieldsMetadataBuilder<>))
                .InScope( scope )
                ;

            kernel
                .Bind( typeof(ITableModelMetadataRepository<>)
                     , typeof(TableModelMetadataRepository<>))
                .To(typeof(TableModelMetadataRepository<>))
                .InScope(scope)
                ;

            kernel
                .Bind( typeof(ITableFieldMetadataRepository<>)
                     , typeof(TableFieldMetadataRepository<>))
                .To(typeof(TableFieldMetadataRepository<>))
                .InScope(scope)
                ;
            
            kernel
               .Bind( typeof( Framework.ViewModels.Tables.Fields.DisplayPolicy.IShouldBeDisplayedOnTable<> ))
               .To( typeof( Framework.ViewModels.Tables.Fields.DisplayPolicy.MetadataBasedPolicy<> ))
               ;
        }
    }
}