using System;
using System.Linq.Expressions;
using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportFieldsMetadataBuilder<S> : IReportFieldsMetadataBuilder<S> {

        public IReportFieldMetadataBuilder<S> for_field<P> ( Expression<Func<S, P>> property_expression ) {
            
            // Improve: this needs to be extracted into a helper method as it is used in the ReportFieldExclusionBuilder
            if ( property_expression.Body.NodeType == ExpressionType.MemberAccess) {
                var expression_body = (MemberExpression)property_expression.Body;
                var property_name = expression_body.Member is PropertyInfo ? expression_body.Member.Name : null;

                return new ReportFieldMetadataBuilder<S>( m => repository.add_metadata(  property_name, m ) );
            }
            throw new Exception( "Could not identify property from the expression." );
        }

        public ReportFieldsMetadataBuilder 
            ( ReportFieldMetadataRepository<S> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

        // repository that stores the setting
        private readonly ReportFieldMetadataRepository<S> repository;

    }

}