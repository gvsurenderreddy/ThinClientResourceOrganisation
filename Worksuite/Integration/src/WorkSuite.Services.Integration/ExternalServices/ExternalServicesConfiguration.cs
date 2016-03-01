namespace WTS.WorkSuite.Services.Integration.ExternalServices {

    internal class ExternalServicesConfiguration  
                    : DomainConfiguration  {

        public ExternalServicesConfiguration 
                      ( ) 
                : base( new ExternalServicesBindings() ) {}
    }
}