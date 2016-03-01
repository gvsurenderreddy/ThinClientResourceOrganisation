using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields.DisplayPolicy;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration {

    public class ReportConfiguration : ADependencyConfiguration  {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {
            
            // reports
            kernel
                .Bind( typeof (IReportModelMetadataRepository<>) 
                     , typeof (ReportModelMetadataRepository<>) )
                .To( typeof (ReportModelMetadataRepository<>) )
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof( IReportModelMetadataBuilder<> ))
                .To( typeof( ReportModelMetadataBuilder<> ))
                ;

            kernel
                .Bind( typeof ( IReportFieldMetadataRepository<> )
                     , typeof ( ReportFieldMetadataRepository<> ))
                .To( typeof ( ReportFieldMetadataRepository<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof( IReportFieldsMetadataBuilder<> ))
                .To ( typeof ( ReportFieldsMetadataBuilder<> ) )
                ;

            kernel
                .Bind( typeof ( IReportActionMetadataRepository<> )
                     , typeof ( ReportActionMetadataRepository<> ))
                .To( typeof ( ReportActionMetadataRepository<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof ( IReportActionsMetadataBuilder<> ))
                .To( typeof( ReportActionsMetadataBuilder<> ) )
                ;

            kernel
                .Bind(  typeof( IShouldBeDisplayedOnReport<> ))
                .To(typeof(AlwaysReturnsTruePolicy<>))
                ;

            kernel
                .Bind( typeof(ActionsBuilder<>) )
                .To(typeof(ActionsBuilder<>))
                ;
        }

    }

}