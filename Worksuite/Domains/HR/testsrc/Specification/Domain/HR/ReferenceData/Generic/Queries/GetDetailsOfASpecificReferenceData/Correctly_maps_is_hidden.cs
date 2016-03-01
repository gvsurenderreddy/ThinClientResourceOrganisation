using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData {

    public abstract class Correctly_maps_is_hidden<E,Eb,R,F>
                             : HRSpecification 
                    where E  : ReferenceDataModel, new() 
                    where Eb : ReferenceDataBuilder<E> 
                    where R  : ReferenceDataDetails
                    where F  : IsAQueryForAnEntityFixture<E,Eb,R> {

        [TestMethod]
        public void when_it_is_true () {
            fixture
                .entity
                .is_hidden( true )
                ;

            fixture.execute_query();

            fixture
                .response
                .result
                .is_hidden
                .Should()
                .BeTrue(  );
        }

        [TestMethod]
        public void when_it_is_false () {
            fixture
                .entity
                .is_hidden( false )
                ;

            fixture.execute_query();

            fixture
                .response
                .result
                .is_hidden
                .Should()
                .BeFalse(  );
        }


        protected override void test_setup() {

            base.test_setup();

            fixture = DependencyResolver.resolve<F>();
        }

        protected F fixture;
    }                 
}