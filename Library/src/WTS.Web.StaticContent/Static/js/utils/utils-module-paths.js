// Requirejs configuration module for the third party libraries

define([], function () {

    return {
        version: '1.0.0',

        paths: {
            'guards': 'Static/js/utils/guard',
            'log_service' : 'Static/js/utils/loggers/log-service',
            'log_provider': 'Static/js/utils/loggers/console-log-provider',
        }
    };
});