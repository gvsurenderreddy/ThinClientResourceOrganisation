// Applies application the module paths confiuration to requirejs. It is 
// used to allow any application specific moduels to be set up as well
// providing the abilty to change any of the library module paths.  

// If we want to change what implements a library module the the path module that
// contains the path definition for the module should be loaded as a depenedency 
// the appropriate path modified.

// e.g. to change the jquery version
//
//     define([ 'library_module_paths', 'module_configuration_builder'], function (library_module_paths,module_configuration) {
//
//       // make any module path configurations changes
//       library_module_paths.jquery = "<new path>";/
//
//       // apply the library module configuration 
//       module_configuration.build();
//
//       ....
// 
//     });

// This module is application and so each application should have its own version.  See
// the WTS.Web.StaticContent/Static/js/Infrastructure/readme.txt for how this file fits
// into setting the library up to be used in an application.

define(["module_configuration_builder"], function (module_configuration) {
    // make any module path configurations changes

    // apply the library module configuration 
    module_configuration.build();

    // apply application specific module configuration


    // return an empty module, this module is to ensure that
    // we have configured requirejs so it is the logic in the
    // consturctor that is called once the module is first 
    // loaded rather than the module itself.

    // This is a bit of a hack, we need it because we are using
    // requirejs to store the default path definitions and we want to make 
    // sure that the module configuration has been applied before we ask requirejs for 
    // any modules.  So we have to wrap all application start scripts in 
    // require that only requires this module this ensures that this configuration 
    // is applied to requirejs before any dependencies are resolved.  This does mean 
    // that this needs to be a module event though there is nothing for the module to do.

    // e.g. an application start script should have the following format
    //
    // require(['application_boot'], function () {
    //
    //    require(['jquery'], function ($) { ... } );
    //
    // });

    define('route_table',[], function () {

        return {
        };
    });

    define( 'page_loader',[], function (){

        return {
            load : function ( url ) {
                this.navigation_requests.push( url );
            },

            navigation_requests: [],
        }
    });

    define( 'dom_test_helpers', [ 'jquery' ], function ( $ ) {
    
        return {

            element_exists: function ( selector  ) {
                return $( selector ).length == 1;
            },
            
            should_have_n_instances_of: function ( n, selector ) {
                 return $( selector ).length == n;
            }

        };

    });


    return {
        version: "1.0.0"
    };
});