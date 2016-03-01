using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.Audit.Infrastructure;

namespace WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base {

    public class AuditSpecification 
                    : Specification {

        protected override void configure_once_before_each_test_is_run 
                                    ( IKernel kernel
                                    , Func<IContext, object> scope ) {

            audit_unit_test_dependency_configuration
                .configure( kernel, scope );

        }

        protected override void configure_once_before_all_tests_are_run 
                                    ( IKernel kernel
                                    , Func<IContext, object> scope ) {

            DomainConfiguration.apply_to( kernel,scope );
        }

        private static readonly AuditUnitTestDependencyConfiguration audit_unit_test_dependency_configuration = new AuditUnitTestDependencyConfiguration();
    }
}