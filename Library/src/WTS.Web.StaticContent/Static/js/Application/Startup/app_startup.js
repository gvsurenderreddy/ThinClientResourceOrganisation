//On startup
//routes has been required just so that the route-data can be eagerly loaded on app startup
require(["page_api", "dom", "feature_degradation", "callbacks"], function (page_api, dom, feature_degradation, callbacks) {

    //Register startup/ajax routine
    callbacks.register(function() {
        //Check the dom for duplicate ID's
        dom.validate_duplicate_ids();


        //run the feature degradation tool
        feature_degradation.execute();
    }).execute();

    

    //render persisted notifications
    page_api.show_persisted_notifications();
});