using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {

    public abstract class FieldIsMappedCorrectlySpecification<P,Q,F,E>
                            : HRResponseCommandSpecification<P, Q, F>
                    where Q : Response 
                    where F : IsAResponseCommandVerifiedByAnEntitiesStateFixture<P,Q,E> {
        

        [TestMethod]
        public void verify () {
            
            fixture.execute_command();

            validate( fixture.request, fixture.entity ).Should().BeTrue();
        }
       
        protected abstract bool validate( P request, E entity );
    }
}