using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Persistence.Framework.Models;
using WTS.WorkSuite.Service.HR.ReferenceData.Generic;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.ReferenceTemplate.Generic;

namespace WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Generic.GetById {

    [TestClass]
    public abstract class Correctly_maps_the_fields<I,P,Q,E,Eb,Er,Eh> 
                : GetById_fixture<I,P,Q,E,Eb,Er,Eh> 
      where I   : ReferenceDataIdentity, new()
      where P   : ReferenceDataDetails 
      where Q   : IReferenceDataGetById<P>
      where E   : ReferenceDataModel, new()
      where Eb  : ReferenceDataBuilder<E> 
      where Er  : FakeReferenceDataRepository<E>  
      where Eh  : ReferenceDataHelper<E,Eb,Er,I>, new( )  {


        [TestMethod]
        public void description_is_mapped ( ) {
            var entity = add_entity(  ).description( "A description" ).entity;
            var response = execute_query( entity );

            response.response.description.Should().Be( entity.description  );
        }
        
        [TestMethod]
        public void is_hidden_is_mapped ( ) {
            var entity = add_entity(  ).description( "A description" ).entity;
            var response = execute_query( entity );

            response.response.is_hidden.Should().Be( entity.is_hidden  );
        }
    }
}