/*
    A module that abstracts away ajax implementation
*/
define(["jquery", "guard", "global", "callbacks", "page_resources", "resources"], function ($, guard, window, callbacks, page_resources, resources) {


    var $jqXHR;
    var requestedDataType;

    var isInstanceOfFormData = function (data) {
        var returnValue;
        try {
            returnValue = (data instanceof (window.FormData));
        } catch (e) {
            returnValue = false;
        }
        return returnValue;
    };

    var ajaxRequest = function (type, url, data, dataType) { // Ajax helper



        var options = {

            //inbound
            dataType: dataType || "json",

            //We don't want the response to be cached
            cache: false,

            //Type or Http method or Http Verb
            type: type,

            data: data ? data : null,

             //Hijack ajax request before send and append custom header
            beforeSend: function (xhr) {
                //We have a hard requirement that every AJAX request sends along the page_id of the page that makes the request.
                //We have a counter-part in our C# code that looks for this custom header.
                //I cannot stress how important it is that the custom header needs to be consistent between the JS code and C# code.

                xhr.setRequestHeader(resources.page_id_header_key, page_resources.current_route_name());
            }
        };

        if (isInstanceOfFormData(data)) {
            //we don't want jQuery messing with Formdata
            options.processData = false;

            //and since jQuery seems to infer the content type when you 
            //don't specify , we want to explicitly set it to false
            options.contentType = false;
        }

        //keep track of the requested dataType
        requestedDataType = options.dataType;

        $jqXHR = $.ajax(url, options);

        return this;
    };

    var success = function (handler) {

        guard.is_not_null_or_undefined($jqXHR, "Need to call execute first");

        $jqXHR.done(function (data, textStatus, jqXHR) {
            if (requestedDataType == "json") {
                guard.is_not_invalid_json(data);
            }

            handler(data);

            callbacks.execute();

        });
        return this;
    };

    var fail = function (handler) {
        guard.is_not_null_or_undefined($jqXHR, "Need to call execute first");

        $jqXHR.fail(function (jqXHR, textStatus, errorThrown) {
            //All of our responses are returned in JSON response objects. So PARSE !!!!
            var data = JSON.parse(jqXHR.responseText);
            handler(data);
        });
        return this;
    };

    return {
        execute: ajaxRequest,
        onsuccess: success,
        onerror: fail
    };
});