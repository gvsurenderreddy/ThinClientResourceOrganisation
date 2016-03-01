/*
    A module that abstracts away null checking
*/
define([], function () {

    function NullorUndefinedException(message) {
        this.message = message;
        this.name = "NullorUndefinedException";
        this.toString = function () {
            return this.name + ": " + this.message;
        };
    }

    function InvalidJsonException(message) {
        this.message = message;
        this.name = "InvalidJsonException";
        this.toString = function () {
            return this.name + ": " + this.message;
        };
    }

    return {
        is_not_null_or_undefined: function (value, message) {

            if (!value) {
                throw new NullorUndefinedException(message);
            }

            return value;
        },
        is_not_invalid_json: function (value, message) {
            if (typeof value != "object") {
                throw new InvalidJsonException(message);
            }

            return value;
        },
        throw_exception: function (message) {
            throw new NullorUndefinedException(message);
        }
    };
});