namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence {


    /// <summary>
    ///     Dependency configuration for the worksuite persistence domain
    /// </summary>
    internal class WorkSuitePersistenceConfiguration
                    : DomainConfiguration {

        public WorkSuitePersistenceConfiguration 
                       ( ) 
                : base ( new WorkSuite.Persistence.EF.Infrastructure.PersistenceEFConfiguration()) {}
    }


}