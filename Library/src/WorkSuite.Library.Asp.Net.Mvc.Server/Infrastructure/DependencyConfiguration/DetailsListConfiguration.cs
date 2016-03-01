using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration {

    public class DetailsListConfiguration : ADependencyConfiguration {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {
            
            kernel
                .Bind( typeof( IDetailsListMetadataRepository<>) 
                     , typeof( DetailsListMetadataRepository<>))
                .To( typeof( DetailsListMetadataRepository<>) )
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof( IDetailsListMetadataBuilder<>) )
                .To( typeof( DetailsListMetadataBuilder<>) )
                ;

            kernel
                .Bind( typeof ( IDetailsListActionMetadataRepository<> )
                     , typeof ( DetailsListActionMetadataRepository<> ))
                .To( typeof ( DetailsListActionMetadataRepository<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof ( IDetailsListActionsMetadataBuilder<>  ) )
                .To( typeof ( DetailsListActionsMetadataBuilder<> ))
                .InSingletonScope()
                ;


            kernel
                .Bind( typeof(DetailsListBuilder<>) )
                .To( typeof(DetailsListBuilder<>))
                ;
        }
    }

}