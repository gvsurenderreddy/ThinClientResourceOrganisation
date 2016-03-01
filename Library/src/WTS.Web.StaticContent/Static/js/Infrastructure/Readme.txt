Navigation
----------

Within the application we will want to navigate to other resources, a resouces is going to either be with in the domain of the application or external.  Within the application when we are navigating to internal resources we want to be able to subvert the browsers standard error handling and deal with that in a custom way as such we have a standard navigation management component that all routing should go through. The standard navigator is a library component but the routes that it navigates to are application specifc so each application will need to define a module, called routes, that provides a list of named routes that the application supports.  If this module is not defined the application will not work.

To routes module should be defined in the 'application-boot-module-configuration.js' module of each application that uses it.


Dependency configuration
------------------------

We want to have the ability to change the implementation of library modules on an application by application basis. But it is quite likely that we will end up with a lot of library modules and we do not want to modify every application that uses the libray everytime we add a new module. So we need a method of having a standard require js configuration for the library that can have module paths (the path to the javascript file that implements the module) modified in the application before they we configure requirejs.  It is also likely that a client is only going to want to override a limitted number of modules so we do not want the client to have to go through the pain of loading all the modules themselves as this is error prone.  

The way we achive this is we have a script that configures requirejs with a set of modules that hold the module path definitions ( /static/js/infrastructure/module-paths.js) and a module that will apply these modules in these module-path modules to the requirejs config ( /static/js/infrastructure/module-configuration-builder.1.js).  This allows a client to get a module-path module, change whatever module paths it wants to and then know that the library will be correctly configured by calling module-configuration-builder.build.  

Unfortunately the way requirejs works is that you can not specify what order require and methods are executed other than after all their dependencies have been loaded.  This is a problem because we need to be sure that the configuration has been applied before any function that needs a dependency is executed otherwise it can not be determined what if any implementation of a module will be provided by requirejs for a requested dependency.  

To get round this problem we have introduced a specific pattern that ensures that the configuration is allways applied before any dependency is resolved.  We have spearated the application into two parts bootstrapping (boot) and start.  Bootstrapping is the sections where configurations is modified and setup and start is where the application logic is started.  So for any entry point the following is expected.


In the .html file there should be 

        <script src="~/Static/js/library/require-js/requirejs-2.1.14.js"></script>     <!-- library -->
        <script src="~/Static/js/Infrastructure/module-paths.1.js"></script>           <!-- library -->
        <script src="~/Tests/boot/application-boot-module-configuration.js"></script>  <!-- application --> 
		<script src="~/Tests/boot/<page-start-script>.js"></script>"                   <!-- application -->

These scripts do the following

  ~/Static/js/library/require-js/requirejs-2.1.14.js 
	This is the implementation of requirejs


  ~/Static/js/Infrastructure/module-paths.1.js 
	Loads the library's module-path modules into requirejs


  ~/Tests/boot/application-boot-module-configuration.js
	This is an application specific script that defines the application-boot module for the application.  Note this could be done as an inline script, it is just if it is going to be used in a lot of pages then it may be sensible to have it in a separate script.

	The application-boot module should make any modification to the library module paths and then apply the library configuration to requirejs via the module-configuration-builder module.

	e.g. 

	define(['library-module-paths','module_configuration_builder'], function ( module_configuration ) {
      // make any module path configurations changes
	  library-module-paths.paths.jquery = "//code.jquery.com/jquery-1.11.1.js"

      // apply the library module configuration 
      module_configuration.build();

      // apply application specific module configuration
	  require.config({
		paths: {
			planned_supply_presenter : "//application/planned_supply/presenter.js" 
		}
	  });


      // return an empty module beacuse this is a mdoule rather than just a require.
      return {
        version: "1.0.0"
      }
    });


A page start script must have the following format

  require(['application-boot'], function()  {

      require([...], function(...){
	    // All page start logic is implemented in here this ensures that the application boot has completed fully before
	    // requirejs atempts to resolve any dependencies.
      });
  });


NOTE - Any modules that are defined in the application do not need to follow the above pattern and should be a simple module definition.