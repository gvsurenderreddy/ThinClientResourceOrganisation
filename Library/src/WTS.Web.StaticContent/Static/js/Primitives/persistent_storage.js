define(["global"], function(window) {

    var localStorage = window.localStorage;

    return{
        set: function(key, value) {
            localStorage.setItem(key, value);
        },
        get: function(key) {
            return localStorage.getItem(key);
        },
        clear: function(key) {
            localStorage.removeItem(key);
        }
    };
});