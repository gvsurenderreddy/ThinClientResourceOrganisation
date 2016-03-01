// Defines the application-boot module path.  The application-boot module
// apply application the module paths confiuration to requirejs. It is 
// used to allow any application specific moduels to be set up as well
// providing the abilty to change any of the library module paths.  

// This module is application and so each application should have its own version.  See
// the WTS.Web.StaticContent/Static/js/Infrastructure/readme.txt for how this file fits
// into setting the library up to be used in an application.

require.config({
    baseUrl: '/',
    paths: {
        application_boot: "Tests/boot/application-boot"
    }
});
