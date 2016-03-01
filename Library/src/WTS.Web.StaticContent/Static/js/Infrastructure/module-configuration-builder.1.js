// Confiugres requirejs with all the library modules.  The module paths are stored 
// in requirejs modules, this allows a client application to change the module paths
// before a module is actually defined in require js.  It allows us to change what 
// implements a dependencies on an application by application basis. 

define(
    ['library_module_paths',
     'utils_module_paths',
     'component_module_paths',
     'subsystem_module_paths'],
    function (
        library_module_paths,
        utils_module_paths,
        component_module_paths,
        subsystem_module_paths
    ) {

        return {
            version: "1.0.0",

            build : function () {
                require.config( library_module_paths );
                require.config( utils_module_paths );
                require.config( component_module_paths );
                require.config( subsystem_module_paths );
            }
        };
});
