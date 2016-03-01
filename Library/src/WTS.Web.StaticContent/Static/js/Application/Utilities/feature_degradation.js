//Graceful degradation module that abstracts away how we swap out components 
//that are not browser supported with the appropriate helpful message


define(["jquery", "global", "underscore"], function ($, window, _) {


    var components = {
        file_upload: {
            has_feature: function () {
                return !!window.FormData;
            },
            selector: "input[type=file]",
            //Ideally, we would like the replacement component/markup coming from the server
            replacement: '<div class="editor-text">Your browser does not support this feature. It is supported in newer browsers.</div>'
        }
    };


    return {
        execute: function () {
            _.each(components, function (component) {
                if (!component.has_feature()) {
                    var $original = $(component.selector);
                    var $replacement = $(component.replacement);

                    $original.hide();
                    $replacement.insertBefore($original);


                }
            });
        }
    };
});