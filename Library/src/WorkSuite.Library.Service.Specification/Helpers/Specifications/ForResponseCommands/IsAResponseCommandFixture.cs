using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands {


    public interface IsAResponseCommandFixture<out P, out Q> 
                where Q : Response {
        
        void execute_command( );

        P request { get; }
        Q response { get; }
    }

}