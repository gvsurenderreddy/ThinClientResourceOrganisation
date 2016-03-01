define(['application_url_builder','module_configuration_builder'], function ( url_builder, module_configuration) {
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


    return {
        version: "1.0.0"
    };
});