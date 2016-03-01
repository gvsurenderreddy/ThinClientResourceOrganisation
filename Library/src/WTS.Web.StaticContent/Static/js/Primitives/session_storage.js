define(["global"], function (window) {

    var sessionStorage = window.sessionStorage;

    return {
        set: function (key, value) {
            sessionStorage.setItem(key, value);
        },
        get: function (key) {
            return sessionStorage.getItem(key);
        },
        clear: function (key) {
            sessionStorage.removeItem(key);
        }
    };
});