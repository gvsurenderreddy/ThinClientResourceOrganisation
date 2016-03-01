using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData {

    public abstract class Correctly_maps_description<E,Eb,R,F>
                             : HRSpecification 
                    where E  : ReferenceDataModel, new() 
                    where Eb : ReferenceDataBuilder<E> 
                    where R  : ReferenceDataDetails
                    where F  : IsAQueryForASetFixture<E,Eb,R> {

        [TestMethod]
        public void is_mapped () {
            var entity = fixture
                            .add()
                            .description( valid_description )
                            .entity;

            fixture.execute_query();

            fixture
                .response
                .result
                .First( member => member.id == entity.id )
                .description
                .Should()
                .Be( entity.description );
        }

        [TestMethod]
        public void leading_white_space_is_trimmed () {
            var entity = fixture
                            .add()
                            .description( white_space + valid_description )
                            .entity;

            fixture.execute_query();

            fixture
                .response
                .result
                .First( member => member.id == entity.id )
                .description
                .Should()
                .Be( valid_description );
        }

        [TestMethod]
        public void trailing_white_space_is_trimmed () {
            var entity = fixture
                            .add()
                            .description( valid_description + white_space )
                            .entity;

            fixture.execute_query();

            fixture
                .response
                .result
                .First( member => member.id == entity.id )
                .description
                .Should()
                .Be( valid_description );
        }


        [TestMethod]
        public void converts_a_null_to_an_empty_string () {
            var entity = fixture
                            .add()
                            .description( null )
                            .entity;

            fixture.execute_query();

            fixture
                .response
                .result
                .First( member => member.id == entity.id )
                .description
                .Should()
                .Be( string.Empty );
        }

        private const string valid_description = "A description";
        private const string white_space       = "   \r\t\n    \t\n";

        protected override void test_setup() {

            base.test_setup();

            fixture = DependencyResolver.resolve<F>();
        }

        protected F fixture;
    }

}