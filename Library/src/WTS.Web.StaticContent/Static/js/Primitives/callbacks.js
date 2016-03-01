define(["underscore"], function(_) {

    var callbacks = [];

    return{
        register: function(callback) {
            callbacks.push(callback);

            return this;
        },
        execute: function() {
            _.each(callbacks, function (callback) {
                callback();
            });
        }
    };
});