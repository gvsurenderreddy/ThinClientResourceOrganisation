using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState {

    public interface IsAResponseCommandVerifiedByAnEntitiesStateFixture<out P,out Q,out E> 
                       : IsAResponseCommandFixture<P,Q> 
               where Q : Response {
        
        E entity { get; }
    }
}