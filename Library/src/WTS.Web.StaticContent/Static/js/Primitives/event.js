/*
    A module that abstracts away event handler binding implementation
*/
define(["global", "jquery", "random"], function (window, $, random) {
    //Inject the window and extract the document :)
    var document = window.document;
    var listen = function (event_name, elementSelector, action) {
        //We can always change the way we bind event handlers to elements this way
        //Todo: Introduce guards
        $(document).on(event_name, elementSelector, function (e, event_data) {
            var target = this;

            e.preventDefault();

            if (!$(target).attr("disabled")) {

                //Give the element an ID if it doesn't have one
                random.generate_dom_id_for_element(target);

                //execute the action
                action(target, event_data);
            }

            return false;
        });
    };


    var custom_listen = function (event_name, elementSelector, callback) {

        if (document.addEventListener) {
            document.addEventListener(event_name, function (e) {
                var target = e.target;
                callback(target, e);
            }, false);
        } else {
            document.documentElement.attachEvent('onpropertychange', function (e) {
                if (e.propertyName == event_name) {
                    var target = e.target;
                    callback(target, e);
                }
            });
        }
    };

    return {
        listen: listen,
        trigger: function (event_name, event_target, event_data) {
            $(event_target).trigger(event_name, event_data);
        },
        custom_listen: custom_listen,
        trigger_custom: function (event_name, event_target, event_data) {
            var event;
            try {
                event = new window.CustomEvent(event_name, { detail: event_data, bubbles: true });

                event_target.dispatchEvent(event);
            } catch (e) {
                //Internet Explorer fallback
                //event = document.createEvent("CustomEvent");
                //event.initCustomEvent(event_name, false, false, event_data);

                window.event_data = event_data;//really shouldn't be doing this, but as we are in shim land. I guess its ok


                if (document.createEvent) {
                    event = document.createEvent('Event');
                    event.initEvent(event_name, true, true);
                    event_target.dispatchEvent(event);
                } else {
                    event = document.documentElement[event_name];
                    event += 1;
                }
            }

        }
    };
});

