using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData {
    
    public abstract class Returns_the_correct_entity<E,Eb,R,F>
                             : HRSpecification 
                    where E  : ReferenceDataModel, new() 
                    where Eb : ReferenceDataBuilder<E> 
                    where R  : ReferenceDataDetails
                    where F  : IsAQueryForAnEntityFixture<E,Eb,R> {
        
            [TestMethod]
            public void the_model_for_the_specified_entity ( ) {
                fixture.execute_query(  );

                fixture.response.result.id.Should().Be( fixture.entity.entity.id );            
            }
        
            protected override void test_setup() {

                base.test_setup();

                fixture = DependencyResolver.resolve<F>();
            }

            protected F fixture; 
      }
}