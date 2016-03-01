// Confiures requirejs with all the module-path modules. 
//

// Version 1.0.0

require.config({
    paths: {
        library_module_paths: "Static/js/library/library-module-paths",
        utils_module_paths: 'Static/js/utils/utils-module-paths',

		component_module_paths: "Static/js/html/component-system/components/component-module-paths",
		subsystem_module_paths: 'Static/js/html/component-system/subsystems/subsystem-module-paths',

		module_configuration_builder: "Static/js/Infrastructure/module-configuration-builder.1"
	}
});